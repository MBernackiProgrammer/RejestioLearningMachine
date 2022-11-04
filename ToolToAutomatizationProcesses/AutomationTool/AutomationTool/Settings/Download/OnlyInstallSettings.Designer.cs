
namespace AutomationTool
{
    partial class OnlyInstallSettings
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
            this.tb_Browace = new System.Windows.Forms.TextBox();
            this.btn_LaunchFolderBrowace = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ch_OwnTitles = new System.Windows.Forms.CheckBox();
            this.tb_OwnTitles = new System.Windows.Forms.TextBox();
            this.L_WritingInfo = new System.Windows.Forms.Label();
            this.btn_Download = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_Browace
            // 
            this.tb_Browace.Location = new System.Drawing.Point(13, 13);
            this.tb_Browace.Name = "tb_Browace";
            this.tb_Browace.Size = new System.Drawing.Size(125, 27);
            this.tb_Browace.TabIndex = 0;
            // 
            // btn_LaunchFolderBrowace
            // 
            this.btn_LaunchFolderBrowace.Location = new System.Drawing.Point(144, 13);
            this.btn_LaunchFolderBrowace.Name = "btn_LaunchFolderBrowace";
            this.btn_LaunchFolderBrowace.Size = new System.Drawing.Size(94, 29);
            this.btn_LaunchFolderBrowace.TabIndex = 1;
            this.btn_LaunchFolderBrowace.Text = "Szukaj";
            this.btn_LaunchFolderBrowace.UseVisualStyleBackColor = true;
            this.btn_LaunchFolderBrowace.Click += new System.EventHandler(this.btn_LaunchFolderBrowace_Click);
            // 
            // ch_OwnTitles
            // 
            this.ch_OwnTitles.AutoSize = true;
            this.ch_OwnTitles.Location = new System.Drawing.Point(13, 47);
            this.ch_OwnTitles.Name = "ch_OwnTitles";
            this.ch_OwnTitles.Size = new System.Drawing.Size(200, 24);
            this.ch_OwnTitles.TabIndex = 2;
            this.ch_OwnTitles.Text = "Własne tytuły wyszukiwań";
            this.ch_OwnTitles.UseVisualStyleBackColor = true;
            this.ch_OwnTitles.CheckedChanged += new System.EventHandler(this.ch_OwnTitles_CheckedChanged);
            // 
            // tb_OwnTitles
            // 
            this.tb_OwnTitles.Enabled = false;
            this.tb_OwnTitles.Location = new System.Drawing.Point(13, 101);
            this.tb_OwnTitles.Multiline = true;
            this.tb_OwnTitles.Name = "tb_OwnTitles";
            this.tb_OwnTitles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_OwnTitles.Size = new System.Drawing.Size(225, 194);
            this.tb_OwnTitles.TabIndex = 3;
            // 
            // L_WritingInfo
            // 
            this.L_WritingInfo.AutoSize = true;
            this.L_WritingInfo.Location = new System.Drawing.Point(13, 78);
            this.L_WritingInfo.Name = "L_WritingInfo";
            this.L_WritingInfo.Size = new System.Drawing.Size(338, 20);
            this.L_WritingInfo.TabIndex = 4;
            this.L_WritingInfo.Text = "Wstaw przecinek, po wpisaniu hasła wyszukiwania";
            // 
            // btn_Download
            // 
            this.btn_Download.Location = new System.Drawing.Point(12, 301);
            this.btn_Download.Name = "btn_Download";
            this.btn_Download.Size = new System.Drawing.Size(94, 29);
            this.btn_Download.TabIndex = 5;
            this.btn_Download.Text = "Pobieraj";
            this.btn_Download.UseVisualStyleBackColor = true;
            this.btn_Download.Click += new System.EventHandler(this.btn_Download_Click);
            // 
            // OnlyInstallSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Download);
            this.Controls.Add(this.L_WritingInfo);
            this.Controls.Add(this.tb_OwnTitles);
            this.Controls.Add(this.ch_OwnTitles);
            this.Controls.Add(this.btn_LaunchFolderBrowace);
            this.Controls.Add(this.tb_Browace);
            this.Name = "OnlyInstallSettings";
            this.Text = "OnlyInstallSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Browace;
        private System.Windows.Forms.Button btn_LaunchFolderBrowace;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox ch_OwnTitles;
        private System.Windows.Forms.TextBox tb_OwnTitles;
        private System.Windows.Forms.Label L_WritingInfo;
        private System.Windows.Forms.Button btn_Download;
    }
}