
namespace AutomationTool
{
    partial class AllSettings
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
            this.btn_Ready = new System.Windows.Forms.Button();
            this.tb_Path = new System.Windows.Forms.TextBox();
            this.btn_Browace = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cb_Install = new System.Windows.Forms.CheckBox();
            this.cb_CheckThatDubled = new System.Windows.Forms.CheckBox();
            this.cb_ScalePhotos = new System.Windows.Forms.CheckBox();
            this.cb_Sort = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_Ready
            // 
            this.btn_Ready.Location = new System.Drawing.Point(13, 256);
            this.btn_Ready.Name = "btn_Ready";
            this.btn_Ready.Size = new System.Drawing.Size(94, 29);
            this.btn_Ready.TabIndex = 0;
            this.btn_Ready.Text = "Gotowe";
            this.btn_Ready.UseVisualStyleBackColor = true;
            this.btn_Ready.Click += new System.EventHandler(this.btn_Ready_Click);
            // 
            // tb_Path
            // 
            this.tb_Path.Location = new System.Drawing.Point(12, 12);
            this.tb_Path.Name = "tb_Path";
            this.tb_Path.Size = new System.Drawing.Size(125, 27);
            this.tb_Path.TabIndex = 1;
            // 
            // btn_Browace
            // 
            this.btn_Browace.Location = new System.Drawing.Point(143, 10);
            this.btn_Browace.Name = "btn_Browace";
            this.btn_Browace.Size = new System.Drawing.Size(94, 29);
            this.btn_Browace.TabIndex = 2;
            this.btn_Browace.Text = "Szukaj";
            this.btn_Browace.UseVisualStyleBackColor = true;
            this.btn_Browace.Click += new System.EventHandler(this.btn_Browace_Click);
            // 
            // cb_Install
            // 
            this.cb_Install.AutoSize = true;
            this.cb_Install.Checked = true;
            this.cb_Install.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Install.Location = new System.Drawing.Point(13, 46);
            this.cb_Install.Name = "cb_Install";
            this.cb_Install.Size = new System.Drawing.Size(78, 24);
            this.cb_Install.TabIndex = 3;
            this.cb_Install.Text = "Instaluj";
            this.cb_Install.UseVisualStyleBackColor = true;
            // 
            // cb_CheckThatDubled
            // 
            this.cb_CheckThatDubled.AutoSize = true;
            this.cb_CheckThatDubled.Checked = true;
            this.cb_CheckThatDubled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_CheckThatDubled.Location = new System.Drawing.Point(13, 77);
            this.cb_CheckThatDubled.Name = "cb_CheckThatDubled";
            this.cb_CheckThatDubled.Size = new System.Drawing.Size(213, 24);
            this.cb_CheckThatDubled.TabIndex = 4;
            this.cb_CheckThatDubled.Text = "Znajduj i usuwaj takie same";
            this.cb_CheckThatDubled.UseVisualStyleBackColor = true;
            // 
            // cb_ScalePhotos
            // 
            this.cb_ScalePhotos.AutoSize = true;
            this.cb_ScalePhotos.Checked = true;
            this.cb_ScalePhotos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ScalePhotos.Location = new System.Drawing.Point(13, 108);
            this.cb_ScalePhotos.Name = "cb_ScalePhotos";
            this.cb_ScalePhotos.Size = new System.Drawing.Size(121, 24);
            this.cb_ScalePhotos.TabIndex = 5;
            this.cb_ScalePhotos.Text = "Skaluj zdjęcia";
            this.cb_ScalePhotos.UseVisualStyleBackColor = true;
            // 
            // cb_Sort
            // 
            this.cb_Sort.AutoSize = true;
            this.cb_Sort.Checked = true;
            this.cb_Sort.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Sort.Location = new System.Drawing.Point(12, 139);
            this.cb_Sort.Name = "cb_Sort";
            this.cb_Sort.Size = new System.Drawing.Size(90, 24);
            this.cb_Sort.TabIndex = 6;
            this.cb_Sort.Text = "Segreguj";
            this.cb_Sort.UseVisualStyleBackColor = true;
            // 
            // AllSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cb_Sort);
            this.Controls.Add(this.cb_ScalePhotos);
            this.Controls.Add(this.cb_CheckThatDubled);
            this.Controls.Add(this.cb_Install);
            this.Controls.Add(this.btn_Browace);
            this.Controls.Add(this.tb_Path);
            this.Controls.Add(this.btn_Ready);
            this.Name = "AllSettings";
            this.Text = "AllSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Ready;
        private System.Windows.Forms.TextBox tb_Path;
        private System.Windows.Forms.Button btn_Browace;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox cb_Install;
        private System.Windows.Forms.CheckBox cb_CheckThatDubled;
        private System.Windows.Forms.CheckBox cb_ScalePhotos;
        private System.Windows.Forms.CheckBox cb_Sort;
    }
}