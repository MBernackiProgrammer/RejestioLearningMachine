
namespace AutomationTool.Settings
{
    partial class CutOnly
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
            this.tb_BrowacePath = new System.Windows.Forms.TextBox();
            this.btn_Browace = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_Cut = new System.Windows.Forms.Button();
            this.tb_X = new System.Windows.Forms.TextBox();
            this.tb_Y = new System.Windows.Forms.TextBox();
            this.L_XName = new System.Windows.Forms.Label();
            this.L_YName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_BrowacePath
            // 
            this.tb_BrowacePath.Location = new System.Drawing.Point(13, 13);
            this.tb_BrowacePath.Name = "tb_BrowacePath";
            this.tb_BrowacePath.Size = new System.Drawing.Size(125, 27);
            this.tb_BrowacePath.TabIndex = 0;
            // 
            // btn_Browace
            // 
            this.btn_Browace.Location = new System.Drawing.Point(144, 11);
            this.btn_Browace.Name = "btn_Browace";
            this.btn_Browace.Size = new System.Drawing.Size(94, 29);
            this.btn_Browace.TabIndex = 1;
            this.btn_Browace.Text = "Szukaj";
            this.btn_Browace.UseVisualStyleBackColor = true;
            this.btn_Browace.Click += new System.EventHandler(this.btn_Browace_Click);
            // 
            // btn_Cut
            // 
            this.btn_Cut.Location = new System.Drawing.Point(12, 99);
            this.btn_Cut.Name = "btn_Cut";
            this.btn_Cut.Size = new System.Drawing.Size(94, 29);
            this.btn_Cut.TabIndex = 2;
            this.btn_Cut.Text = "Przytnij";
            this.btn_Cut.UseVisualStyleBackColor = true;
            this.btn_Cut.Click += new System.EventHandler(this.btn_Cut_Click);
            // 
            // tb_X
            // 
            this.tb_X.Location = new System.Drawing.Point(12, 66);
            this.tb_X.Name = "tb_X";
            this.tb_X.Size = new System.Drawing.Size(125, 27);
            this.tb_X.TabIndex = 3;
            // 
            // tb_Y
            // 
            this.tb_Y.Location = new System.Drawing.Point(143, 66);
            this.tb_Y.Name = "tb_Y";
            this.tb_Y.Size = new System.Drawing.Size(125, 27);
            this.tb_Y.TabIndex = 4;
            // 
            // L_XName
            // 
            this.L_XName.AutoSize = true;
            this.L_XName.Location = new System.Drawing.Point(13, 47);
            this.L_XName.Name = "L_XName";
            this.L_XName.Size = new System.Drawing.Size(21, 20);
            this.L_XName.TabIndex = 5;
            this.L_XName.Text = "X:";
            // 
            // L_YName
            // 
            this.L_YName.AutoSize = true;
            this.L_YName.Location = new System.Drawing.Point(144, 47);
            this.L_YName.Name = "L_YName";
            this.L_YName.Size = new System.Drawing.Size(20, 20);
            this.L_YName.TabIndex = 6;
            this.L_YName.Text = "Y:";
            // 
            // CutOnly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.L_YName);
            this.Controls.Add(this.L_XName);
            this.Controls.Add(this.tb_Y);
            this.Controls.Add(this.tb_X);
            this.Controls.Add(this.btn_Cut);
            this.Controls.Add(this.btn_Browace);
            this.Controls.Add(this.tb_BrowacePath);
            this.Name = "CutOnly";
            this.Text = "CutOnly";
            this.Load += new System.EventHandler(this.CutOnly_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_BrowacePath;
        private System.Windows.Forms.Button btn_Browace;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_Cut;
        private System.Windows.Forms.TextBox tb_X;
        private System.Windows.Forms.TextBox tb_Y;
        private System.Windows.Forms.Label L_XName;
        private System.Windows.Forms.Label L_YName;
    }
}