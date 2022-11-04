
namespace AutomationTool.Settings
{
    partial class ChangeName
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
            this.btn_Browace = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tb_PreForm = new System.Windows.Forms.TextBox();
            this.btn_Strart = new System.Windows.Forms.Button();
            this.L_PreForm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_Browace
            // 
            this.tb_Browace.Location = new System.Drawing.Point(13, 13);
            this.tb_Browace.Name = "tb_Browace";
            this.tb_Browace.Size = new System.Drawing.Size(125, 27);
            this.tb_Browace.TabIndex = 0;
            // 
            // btn_Browace
            // 
            this.btn_Browace.Location = new System.Drawing.Point(145, 13);
            this.btn_Browace.Name = "btn_Browace";
            this.btn_Browace.Size = new System.Drawing.Size(94, 29);
            this.btn_Browace.TabIndex = 1;
            this.btn_Browace.Text = "Szukaj";
            this.btn_Browace.UseVisualStyleBackColor = true;
            this.btn_Browace.Click += new System.EventHandler(this.btn_Browace_Click);
            // 
            // tb_PreForm
            // 
            this.tb_PreForm.Location = new System.Drawing.Point(12, 109);
            this.tb_PreForm.Name = "tb_PreForm";
            this.tb_PreForm.Size = new System.Drawing.Size(125, 27);
            this.tb_PreForm.TabIndex = 2;
            // 
            // btn_Strart
            // 
            this.btn_Strart.Location = new System.Drawing.Point(13, 190);
            this.btn_Strart.Name = "btn_Strart";
            this.btn_Strart.Size = new System.Drawing.Size(94, 29);
            this.btn_Strart.TabIndex = 3;
            this.btn_Strart.Text = "Start";
            this.btn_Strart.UseVisualStyleBackColor = true;
            this.btn_Strart.Click += new System.EventHandler(this.btn_Strart_Click);
            // 
            // L_PreForm
            // 
            this.L_PreForm.AutoSize = true;
            this.L_PreForm.Location = new System.Drawing.Point(13, 78);
            this.L_PreForm.Name = "L_PreForm";
            this.L_PreForm.Size = new System.Drawing.Size(69, 20);
            this.L_PreForm.TabIndex = 4;
            this.L_PreForm.Text = "Preform :";
            // 
            // ChangeName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.L_PreForm);
            this.Controls.Add(this.btn_Strart);
            this.Controls.Add(this.tb_PreForm);
            this.Controls.Add(this.btn_Browace);
            this.Controls.Add(this.tb_Browace);
            this.Name = "ChangeName";
            this.Text = "ChangeName";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Browace;
        private System.Windows.Forms.Button btn_Browace;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox tb_PreForm;
        private System.Windows.Forms.Button btn_Strart;
        private System.Windows.Forms.Label L_PreForm;
    }
}