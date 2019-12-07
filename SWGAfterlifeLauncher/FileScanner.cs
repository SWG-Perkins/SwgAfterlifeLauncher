using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;
using System.Windows.Forms;

namespace SWGAfterlifeLauncher
{
    class FileScanner
    {
        private bool tcFlag;
        private string swgClientFolder;
        private string swgClientFolderBase;
        private FileManifest[] manifest;

        /// <summary>
        /// FileScanner constructor
        /// </summary>
        /// <param name="SwgClientFolder"></param>
        /// <param name="TCFlag"></param>
        public FileScanner(string SwgClientFolder, bool TCFlag)
        {
            tcFlag = TCFlag;
            swgClientFolder = SwgClientFolder;
            swgClientFolderBase = SwgClientFolder;

            if (tcFlag)
            {
                swgClientFolder = Path.Combine(swgClientFolder, StrResources.TCFolder);
            }
        }

        /// <summary>
        /// Appends Test Center folder name to the URL, if necessary
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        private Uri GetFinalUrl(string Url)
        {
            Uri finalUrl = new Uri(Url);
            
            if (tcFlag)
            {
                finalUrl = new Uri(finalUrl, StrResources.TCFolder + "/"); 
            }
            return finalUrl;
        }

        /// <summary>
        /// Create the screenshot folder if necessary.
        /// </summary>
        public void CheckScreenshotFolder()
        {
            string directoryName;

            try
            {
                directoryName = Path.Combine(swgClientFolderBase, StrResources.ScreenshotFolder);

                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
            }
            catch (Exception ex)
            {
                Utils.HandleError(ex, "Error creating screenshot folder");
            }
        }

        /// <summary>
        /// Tests for the existence of the test center folder.
        /// </summary>
        /// <returns></returns>
        public bool TCFolderExists()
        {
            return Directory.Exists(swgClientFolder);
        }

        /// <summary>
        /// Creates a Test Center folder and copies all the base folder files into it
        /// </summary>
        /// <returns></returns>
        public bool CreateTCClient()
        {
            bool success = true;

            if (Utils.DirectoryCopy(swgClientFolderBase, swgClientFolder))
            {
                // Create profile and screenshot folder
                try
                {
                    Directory.CreateDirectory(Path.Combine(swgClientFolder, StrResources.ProfileFolder));
                    Directory.CreateDirectory(Path.Combine(swgClientFolder, StrResources.ScreenshotFolder));
                }
                catch (Exception ex)
                {
                    success = false;
                    Utils.HandleError(ex, "Error creating directory");
                }

                // Copy Miles Sound folder if it exists
                string milesPath = Path.Combine(swgClientFolderBase, StrResources.MilesFolder);

                if (Directory.Exists(milesPath))
                {
                    success = Utils.DirectoryCopy(
                        milesPath,
                        Path.Combine(swgClientFolder, StrResources.MilesFolder)
                    );
                }
            }
            else
            {
                success = false;
            }

            return success;
        }

        /// <summary>
        /// The size of the actual file on disk
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        private long GetFileSize(string FileName)
        {
            long fileSize = -1;
            try
            {
                fileSize = new System.IO.FileInfo(Path.Combine(swgClientFolder, FileName)).Length;
            }
            catch (Exception ex)
            {
                Utils.HandleError(ex, "Error finding file size");
            }
            return fileSize;
        }

        /// <summary>
        /// The computed MD5 hash of the actual file on disk
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        private string GetMd5Hash(string FileName)
        {
            string fileHash = String.Empty;
            var md5 = MD5.Create();

            try
            {
                var stream = File.OpenRead(Path.Combine(swgClientFolder, FileName));
                fileHash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", String.Empty);
                stream.Close();
                stream.Dispose();
            }
            catch (Exception ex)
            {
                Utils.HandleError(ex, "Error getting file hash");
            }
            md5.Dispose();
            return fileHash;
        }

        /// <summary>
        /// Scan the file, either by comparing file sizes or by MD5 hashes
        /// </summary>
        /// <param name="i"></param>
        /// <param name="VerifyHash"></param>
        /// <returns></returns>
        public bool ScanFile(int i, bool VerifyHash)
        {
            bool success;
            if (!VerifyHash)
            {
                success = manifest[i].FileSize ==
                    GetFileSize(Path.Combine(swgClientFolder, manifest[i].FileName));
            }
            else
            {
                success = manifest[i].Md5Hash.ToLower() ==
                    GetMd5Hash(Path.Combine(swgClientFolder, manifest[i].FileName)).ToLower();
            }

            return success;
        }

        /// <summary>
        /// Checks existence of the file
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool DoesFileExist(int i)
        {
            return File.Exists(Path.Combine(swgClientFolder, manifest[i].FileName));
        }

        /// <summary>
        /// Number of files to scan
        /// </summary>
        /// <returns></returns>
        public int FileCount()
        {
            int result = 0;

            if (manifest != null)
            {
                result = manifest.Length;
            }

            return result;
        }

        /// <summary>
        /// Download a SWG Afterlife program file
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool DownloadFile(int i)
        {
            bool success = true;
            var client = new WebClient();

            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                client.DownloadFile(
                    new Uri(GetFinalUrl(StrResources.ClientFileUrl), manifest[i].FileName).ToString(),
                    Path.Combine(swgClientFolder, manifest[i].FileName)
                );
            }
            catch (Exception ex)
            {
                success = false;
                Utils.HandleError(ex, "Error downloading file");
            }

            client.Dispose();
            return success;
        }

        /// <summary>
        /// Return the filename of the appropriate row
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string FileName(int i)
        {
            return manifest[i].FileName;
        }

        /// <summary>
        /// Downloads the game file manifest the web host, loads it into a stream,
        /// and then populates the CSV object collection
        /// </summary>
        /// <returns></returns>
        public bool LoadManifest()
        {
            bool success = true;

            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                Uri manifestUri = new Uri(GetFinalUrl(StrResources.ClientFileUrl), StrResources.MftFilename);
                WebRequest req = WebRequest.Create(manifestUri);
                WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();
                TextReader textRead = new StreamReader(stream);
                var manifestFile = new FileHelperEngine<FileManifest>();

                manifest = manifestFile.ReadStream(textRead);

                textRead.Dispose();
                stream.Dispose();
                response.Dispose();
            }
            catch (Exception ex)
            {
                success = false;
                Utils.HandleError(ex, "Error downloading file manifest");
            }            
            return success;
        }
    }
}
