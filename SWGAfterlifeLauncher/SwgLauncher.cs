using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWGAfterlifeLauncher;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Forms;

namespace SWGAfterlifeLauncher
{
    public class SwgLauncher
    {
        private string swgClientFolder;
        public string SwgClientFolder { get => swgClientFolder; private set => swgClientFolder = value; }

        /// <summary>
        /// Constructor
        /// </summary>
        public SwgLauncher()
        {
            swgClientFolder = Properties.Settings.Default.SwgClientFolder;
        }

        /// <summary>
        /// Select the folder containing the SWGEmu application files.
        /// </summary>
        /// <returns></returns>
        public string SelectAppFolder()
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                swgClientFolder = dialog.FileName;
            }

            SaveConfigInfo();
            dialog.Dispose();
            return swgClientFolder;
        }

        /// <summary>
        /// Saves the location of the client folder
        /// </summary>
        /// <returns></returns>
        private bool SaveConfigInfo()
        {
            bool result = true;

            try
            {
                Properties.Settings.Default.SwgClientFolder = swgClientFolder;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                result = false;
                Utils.HandleError(ex, "Error Saving Folder Location");
            }
            return result;
        }

        /// <summary>
        /// Launch the SWGEmu client
        /// </summary>
        public void Launch(bool tcFlag)
        {
            try
            {
                Utils.RunFile(FinalFolderPath(tcFlag), StrResources.ClientFilename);
            }
            catch (Exception ex)
            {
                Utils.HandleError(ex, "Error launching SWGEmu client");
            }
        }

        /// <summary>
        /// Launch the SWGEmu client setup
        /// </summary>
        public void RunClientSetup(bool tcFlag)
        {
            try
            {
                Utils.RunFile(FinalFolderPath(tcFlag), StrResources.SetupFilename);
            }
            catch (Exception ex)
            {
                Utils.HandleError(ex, "Error launching SWGEmu setup");
            }
        }

        /// <summary>
        /// Returns the folder name and includes the Test Center subfolder if necessary
        /// </summary>
        /// <param name="tcFlag"></param>
        /// <returns></returns>
        private string FinalFolderPath(bool tcFlag)
        {
            string folder = swgClientFolder;
            if (tcFlag)
            {
                folder = Path.Combine(swgClientFolder, StrResources.TCFolder);
            }
            return folder;
        }
    }
}
