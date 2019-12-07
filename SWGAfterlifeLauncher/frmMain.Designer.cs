namespace SWGAfterlifeLauncher
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.txtProgramFolder = new System.Windows.Forms.TextBox();
            this.cmdSelectProgramFolder = new System.Windows.Forms.Button();
            this.lblSelectionNotification = new System.Windows.Forms.Label();
            this.cboServer = new System.Windows.Forms.ComboBox();
            this.cmdClientSetup = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdScanFiles = new System.Windows.Forms.Button();
            this.cmdLaunch = new System.Windows.Forms.Button();
            this.prgUpdateFiles = new System.Windows.Forms.ProgressBar();
            this.prgScanFiles = new System.Windows.Forms.ProgressBar();
            this.prgFilesForLaunch = new System.Windows.Forms.ProgressBar();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Magenta;
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "SWG Program Folder:";
            // 
            // txtProgramFolder
            // 
            this.txtProgramFolder.BackColor = System.Drawing.SystemColors.Window;
            this.txtProgramFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgramFolder.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtProgramFolder.Location = new System.Drawing.Point(133, 14);
            this.txtProgramFolder.Name = "txtProgramFolder";
            this.txtProgramFolder.ReadOnly = true;
            this.txtProgramFolder.Size = new System.Drawing.Size(367, 23);
            this.txtProgramFolder.TabIndex = 1;
            this.txtProgramFolder.TabStop = false;
            // 
            // cmdSelectProgramFolder
            // 
            this.cmdSelectProgramFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSelectProgramFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelectProgramFolder.Location = new System.Drawing.Point(509, 14);
            this.cmdSelectProgramFolder.Name = "cmdSelectProgramFolder";
            this.cmdSelectProgramFolder.Size = new System.Drawing.Size(83, 23);
            this.cmdSelectProgramFolder.TabIndex = 2;
            this.cmdSelectProgramFolder.Text = "Select";
            this.cmdSelectProgramFolder.UseVisualStyleBackColor = true;
            this.cmdSelectProgramFolder.Click += new System.EventHandler(this.cmdSelectProgramFolder_Click);
            // 
            // lblSelectionNotification
            // 
            this.lblSelectionNotification.AutoSize = true;
            this.lblSelectionNotification.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectionNotification.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectionNotification.ForeColor = System.Drawing.Color.Lime;
            this.lblSelectionNotification.Location = new System.Drawing.Point(141, 40);
            this.lblSelectionNotification.Name = "lblSelectionNotification";
            this.lblSelectionNotification.Size = new System.Drawing.Size(347, 15);
            this.lblSelectionNotification.TabIndex = 3;
            this.lblSelectionNotification.Text = "***** Please select the folder containing the SWG client files *****";
            this.lblSelectionNotification.Visible = false;
            // 
            // cboServer
            // 
            this.cboServer.BackColor = System.Drawing.SystemColors.Window;
            this.cboServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboServer.FormattingEnabled = true;
            this.cboServer.Location = new System.Drawing.Point(133, 58);
            this.cboServer.Name = "cboServer";
            this.cboServer.Size = new System.Drawing.Size(367, 23);
            this.cboServer.TabIndex = 4;
            this.cboServer.TabStop = false;
            this.cboServer.Visible = false;
            this.cboServer.SelectionChangeCommitted += new System.EventHandler(this.cboServer_SelectionChangeCommitted);
            // 
            // cmdClientSetup
            // 
            this.cmdClientSetup.Enabled = false;
            this.cmdClientSetup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdClientSetup.Location = new System.Drawing.Point(473, 492);
            this.cmdClientSetup.Name = "cmdClientSetup";
            this.cmdClientSetup.Size = new System.Drawing.Size(119, 34);
            this.cmdClientSetup.TabIndex = 5;
            this.cmdClientSetup.Text = "SWG Client Setup";
            this.cmdClientSetup.UseVisualStyleBackColor = true;
            this.cmdClientSetup.Click += new System.EventHandler(this.cmdClientSetup_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Enabled = false;
            this.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdUpdate.Location = new System.Drawing.Point(473, 532);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(119, 34);
            this.cmdUpdate.TabIndex = 6;
            this.cmdUpdate.Text = "Check for Updates";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdScanFiles
            // 
            this.cmdScanFiles.Enabled = false;
            this.cmdScanFiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdScanFiles.Location = new System.Drawing.Point(473, 572);
            this.cmdScanFiles.Name = "cmdScanFiles";
            this.cmdScanFiles.Size = new System.Drawing.Size(119, 34);
            this.cmdScanFiles.TabIndex = 7;
            this.cmdScanFiles.Text = "Scan Files";
            this.cmdScanFiles.UseVisualStyleBackColor = true;
            this.cmdScanFiles.Click += new System.EventHandler(this.cmdScanFiles_Click);
            // 
            // cmdLaunch
            // 
            this.cmdLaunch.Enabled = false;
            this.cmdLaunch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdLaunch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLaunch.Location = new System.Drawing.Point(473, 612);
            this.cmdLaunch.Name = "cmdLaunch";
            this.cmdLaunch.Size = new System.Drawing.Size(119, 34);
            this.cmdLaunch.TabIndex = 8;
            this.cmdLaunch.Text = "Launch Game";
            this.cmdLaunch.UseVisualStyleBackColor = true;
            this.cmdLaunch.Click += new System.EventHandler(this.cmdLaunch_Click);
            // 
            // prgUpdateFiles
            // 
            this.prgUpdateFiles.Location = new System.Drawing.Point(12, 540);
            this.prgUpdateFiles.Name = "prgUpdateFiles";
            this.prgUpdateFiles.Size = new System.Drawing.Size(451, 18);
            this.prgUpdateFiles.TabIndex = 9;
            // 
            // prgScanFiles
            // 
            this.prgScanFiles.Location = new System.Drawing.Point(12, 580);
            this.prgScanFiles.Name = "prgScanFiles";
            this.prgScanFiles.Size = new System.Drawing.Size(451, 18);
            this.prgScanFiles.TabIndex = 10;
            // 
            // prgFilesForLaunch
            // 
            this.prgFilesForLaunch.Location = new System.Drawing.Point(12, 620);
            this.prgFilesForLaunch.Name = "prgFilesForLaunch";
            this.prgFilesForLaunch.Size = new System.Drawing.Size(451, 18);
            this.prgFilesForLaunch.TabIndex = 11;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.BackColor = System.Drawing.Color.Transparent;
            this.lblServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.ForeColor = System.Drawing.Color.Magenta;
            this.lblServer.Location = new System.Drawing.Point(85, 61);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(42, 15);
            this.lblServer.TabIndex = 12;
            this.lblServer.Text = "Server:";
            this.lblServer.Visible = false;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.Black;
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatus.ForeColor = System.Drawing.Color.Magenta;
            this.txtStatus.Location = new System.Drawing.Point(12, 652);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(580, 16);
            this.txtStatus.TabIndex = 13;
            this.txtStatus.TabStop = false;
            this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(604, 670);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.prgFilesForLaunch);
            this.Controls.Add(this.prgScanFiles);
            this.Controls.Add(this.prgUpdateFiles);
            this.Controls.Add(this.cmdLaunch);
            this.Controls.Add(this.cmdScanFiles);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.cmdClientSetup);
            this.Controls.Add(this.cboServer);
            this.Controls.Add(this.lblSelectionNotification);
            this.Controls.Add(this.cmdSelectProgramFolder);
            this.Controls.Add(this.txtProgramFolder);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "SWG Afterlife";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProgramFolder;
        private System.Windows.Forms.Button cmdSelectProgramFolder;
        private System.Windows.Forms.Label lblSelectionNotification;
        private System.Windows.Forms.ComboBox cboServer;
        private System.Windows.Forms.Button cmdClientSetup;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Button cmdScanFiles;
        private System.Windows.Forms.Button cmdLaunch;
        private System.Windows.Forms.ProgressBar prgUpdateFiles;
        private System.Windows.Forms.ProgressBar prgScanFiles;
        private System.Windows.Forms.ProgressBar prgFilesForLaunch;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtStatus;
    }
}

