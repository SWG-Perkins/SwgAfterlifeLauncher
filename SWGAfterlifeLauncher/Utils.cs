using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWGAfterlifeLauncher
{
    class Utils
    {
        /// <summary>
        /// This is a generic error handler.  Errors are display on-screen.
        /// </summary>
        /// <param name="oEx"></param>
        /// <param name="sMsgBoxTitle"></param>
        public static void HandleError(Exception oEx, string sMsgBoxTitle)
        {
            MessageBox.Show(oEx.Message, sMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Run an executable file
        /// </summary>
        /// <param name="DirectoryName"></param>
        /// <param name="FileName"></param>
        public static void RunFile(string DirectoryName, string FileName)
        {
            // we need to specify the working directory
            ProcessStartInfo startInfo;
            startInfo = new ProcessStartInfo(FileName);
            startInfo.WorkingDirectory = DirectoryName;

            Process.Start(startInfo);
        }

        /// <summary>
        /// Copy files in Source directory into Target directory
        /// </summary>
        /// <param name="sourceDirName"></param>
        /// <param name="destDirName"></param>
        /// <returns></returns>
        public static bool DirectoryCopy(string sourceDirName, string destDirName)
        {
            var success = true;

            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                success = false;
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }
            else
            {

                try
                {
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    // If the destination directory doesn't exist, create it.
                    if (!Directory.Exists(destDirName))
                    {
                        Directory.CreateDirectory(destDirName);
                    }

                    // Get the files in the directory and copy them to the new location.
                    FileInfo[] files = dir.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        string temppath = Path.Combine(destDirName, file.Name);
                        file.CopyTo(temppath, false);
                    }
                }
                catch (Exception ex)
                {
                    success = false;
                    HandleError(ex, "Error copying directory");
                }

            }

            return success;
        }
    }
}
