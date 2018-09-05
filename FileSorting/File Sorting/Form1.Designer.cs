namespace File_Sorting
{
    partial class frmMain
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
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.txtDestPath = new System.Windows.Forms.TextBox();
            this.lbWatchedFolders = new System.Windows.Forms.ListBox();
            this.btnDestination = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtFileSamp = new System.Windows.Forms.TextBox();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.fdFolderChoice = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(696, 354);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(74, 23);
            this.btnDisplay.TabIndex = 0;
            this.btnDisplay.Text = "Open File";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(94, 77);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(75, 23);
            this.btnAddFile.TabIndex = 1;
            this.btnAddFile.Text = "Add File";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // txtDestPath
            // 
            this.txtDestPath.Location = new System.Drawing.Point(239, 228);
            this.txtDestPath.Name = "txtDestPath";
            this.txtDestPath.ReadOnly = true;
            this.txtDestPath.Size = new System.Drawing.Size(237, 20);
            this.txtDestPath.TabIndex = 2;
            // 
            // lbWatchedFolders
            // 
            this.lbWatchedFolders.FormattingEnabled = true;
            this.lbWatchedFolders.Location = new System.Drawing.Point(197, 64);
            this.lbWatchedFolders.Name = "lbWatchedFolders";
            this.lbWatchedFolders.Size = new System.Drawing.Size(279, 95);
            this.lbWatchedFolders.TabIndex = 3;
            // 
            // btnDestination
            // 
            this.btnDestination.Location = new System.Drawing.Point(47, 226);
            this.btnDestination.Name = "btnDestination";
            this.btnDestination.Size = new System.Drawing.Size(154, 23);
            this.btnDestination.TabIndex = 4;
            this.btnDestination.Text = "Choose Destination Folder";
            this.btnDestination.UseVisualStyleBackColor = true;
            this.btnDestination.Click += new System.EventHandler(this.btnDestination_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(452, 389);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 5;
            this.btnSelectFile.Text = "Choose File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click_1);
            // 
            // txtFileSamp
            // 
            this.txtFileSamp.Location = new System.Drawing.Point(533, 392);
            this.txtFileSamp.Name = "txtFileSamp";
            this.txtFileSamp.ReadOnly = true;
            this.txtFileSamp.Size = new System.Drawing.Size(237, 20);
            this.txtFileSamp.TabIndex = 6;
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Location = new System.Drawing.Point(94, 122);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFile.TabIndex = 7;
            this.btnRemoveFile.Text = "Remove File";
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRemoveFile);
            this.Controls.Add(this.txtFileSamp);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.btnDestination);
            this.Controls.Add(this.lbWatchedFolders);
            this.Controls.Add(this.txtDestPath);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.btnDisplay);
            this.Name = "frmMain";
            this.Text = "File Sorting";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.TextBox txtDestPath;
        private System.Windows.Forms.ListBox lbWatchedFolders;
        private System.Windows.Forms.Button btnDestination;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtFileSamp;
        private System.Windows.Forms.Button btnRemoveFile;
        private System.Windows.Forms.FolderBrowserDialog fdFolderChoice;
    }
}

