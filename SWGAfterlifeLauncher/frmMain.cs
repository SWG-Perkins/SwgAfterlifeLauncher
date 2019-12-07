using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWGAfterlifeLauncher
{
    public partial class FrmMain : Form
    {
        private SwgLauncher launcher;

        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Indicates whether the test center folder is selected. Returns boolean.
        /// </summary>
        /// <returns></returns>
        private bool IsTestCenter()
        {
            return (cboServer.Text == StrResources.ServerNameTC);
        }

        /// <summary>
        /// Disable all command buttons.  Used during scans.
        /// </summary>
        private void DisableAllButtons()
        {
            cmdSelectProgramFolder.Enabled = false;
            cmdUpdate.Enabled = false;
            cmdLaunch.Enabled = false;
            cmdScanFiles.Enabled = false;
            cmdClientSetup.Enabled = false;
        }

        /// <summary>
        /// Enable or disable some controls depending on whether or not the
        /// SWG Program Folder is selected.
        /// </summary>
        private void SetButtons()
        {
            bool buttonsEnabled = !(txtProgramFolder.Text.Trim() == String.Empty);
            cboServer.Visible = buttonsEnabled;
            cmdSelectProgramFolder.Enabled = true;
            cmdClientSetup.Enabled = buttonsEnabled;
            cmdLaunch.Enabled = buttonsEnabled;
            cmdScanFiles.Enabled = buttonsEnabled;
            cmdUpdate.Enabled = buttonsEnabled;
            lblSelectionNotification.Visible = !buttonsEnabled;
            lblServer.Visible = buttonsEnabled;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            launcher = new SwgLauncher();
            txtProgramFolder.Text = launcher.SwgClientFolder;
            SetButtons();
            cboServer.Items.Add(StrResources.ServerNameLive);
            cboServer.Items.Add(StrResources.ServerNameTC);
            cboServer.Text = StrResources.ServerNameLive;
        }

        private void cmdSelectProgramFolder_Click(object sender, EventArgs e)
        {
            txtProgramFolder.Text = launcher.SelectAppFolder();

            if (txtProgramFolder.Text.Trim() != string.Empty)
            {
                if (CheckFiles(prgFilesForLaunch, false))
                {
                    SetButtons();
                }
            }
        }

        private void cmdClientSetup_Click(object sender, EventArgs e)
        {
            launcher.RunClientSetup(IsTestCenter());
        }

        private void cmdLaunch_Click(object sender, EventArgs e)
        {
            launcher.Launch(IsTestCenter());
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            CheckFiles(prgUpdateFiles, false);
        }

        private void SetStatus(string statusText)
        {
            txtStatus.Text = statusText;
            Refresh();
        }

        /// <summary>
        /// Initiate check and/or download of game files. 
        /// Only show scan status during MD5 check
        /// </summary>
        private bool CheckFiles (ProgressBar prgBar, bool verifyHash)
        {
            bool success = false;

            Cursor.Current = Cursors.WaitCursor;
            DisableAllButtons();

            SetStatus(StrResources.StatusGettingManifest);

            prgBar.Value = 3;
            var fileScanner = new FileScanner(launcher.SwgClientFolder, IsTestCenter());

            // Check if we need to setup the Test Center folder on the user's PC
            if (IsTestCenter())
            {
                success = false;
                if (!fileScanner.TCFolderExists())
                {
                    if (MessageBox.Show(StrResources.TCInstallConfirmation,
                        "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SetStatus(StrResources.StatusCreatingTCFolder);
                        success = fileScanner.CreateTCClient();
                    }
                }
                else
                {
                    success = true;
                }
            }
            else
            {
                success = true;
            }

            if (success)
            {
                // Load the file manifest into the file scanner
                fileScanner.LoadManifest();

                if (!verifyHash)
                {
                    SetStatus(StrResources.StatusQuickCheck);
                }

                int fileCount = fileScanner.FileCount();
                bool triggerFileDownload = false;
                int i = 0;

                while (i < fileCount && success)
                {
                    // If the file doesn't exist locally, ask the user if they
                    // want to download the file
                    if (!fileScanner.DoesFileExist(i))
                    {
                        if (!triggerFileDownload)
                        {
                            triggerFileDownload =
                                (MessageBox.Show(StrResources.DownloadConfirmation,
                                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                == DialogResult.Yes);
                        }
                        
                        if (triggerFileDownload)
                        {
                            SetStatus(StrResources.StatusDownloadingFile + fileScanner.FileName(i));
                            success = fileScanner.DownloadFile(i);
                        }
                        else
                        {
                            // The user has chosen not to download the file, so discontinue
                            // the file check.
                            success = false;
                            MessageBox.Show(StrResources.StatusFilesMissing);
                        }
                    }

                    if (success)
                    {
                        if (verifyHash)
                        {
                            SetStatus(StrResources.StatusScanningFile + fileScanner.FileName(i));
                        }

                        prgBar.Value = 100 / fileCount * (i + 1);
                        Refresh();

                        // Scan the file
                        success = fileScanner.ScanFile(i, verifyHash);

                        if (!success)
                        {
                            //The file did not scan properly, so try to re-download it.
                            SetStatus(StrResources.StatusDownloadingFile + fileScanner.FileName(i));
                            success = fileScanner.DownloadFile(i);
                        }

                        if (success)
                        {
                            i += 1;
                        }
                        else
                        {
                            // The file did not download successfully.  Fail the process
                            // and notify the user
                            SetStatus(fileScanner.FileName(i) + StrResources.StatusDownloadFailed);
                        }
                    }
                }
            }

            if (success)
            {
                prgBar.Value = 100;
                SetStatus(StrResources.StatusReady);
                SetButtons();
            }
            else
            {
                // Disable all buttons except for "Select Folder" and "Check for Update"
                DisableAllButtons();
                cmdSelectProgramFolder.Enabled = true;
                cmdUpdate.Enabled = true;
                prgBar.Value = 0;
            }

            Cursor.Current = Cursors.Default;
            return success;
        }

        private void cmdScanFiles_Click(object sender, EventArgs e)
        {
            // Do full scan with MD5 hash checking
            CheckFiles(prgScanFiles, true);
        }

        private void cboServer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Perform quick scan after changing the server option
            CheckFiles(prgUpdateFiles, false);
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            if (txtProgramFolder.Text.Trim() != string.Empty)
            {
                // Perform initial file check when loading the app
                if (CheckFiles(prgFilesForLaunch, false))
                {
                    SetButtons();
                }
            }
        }
    }
}
