
namespace AutomationTool.ErrorInfo
{
    partial class AutoToolErrorInfo
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
            this.L_Nazwa = new System.Windows.Forms.Label();
            this.L_Value = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // L_Nazwa
            // 
            this.L_Nazwa.AutoSize = true;
            this.L_Nazwa.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.L_Nazwa.Location = new System.Drawing.Point(13, 13);
            this.L_Nazwa.Name = "L_Nazwa";
            this.L_Nazwa.Size = new System.Drawing.Size(81, 35);
            this.L_Nazwa.TabIndex = 0;
            this.L_Nazwa.Text = "label1";
            // 
            // L_Value
            // 
            this.L_Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_Value.Location = new System.Drawing.Point(0, 0);
            this.L_Value.Name = "L_Value";
            this.L_Value.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.L_Value.Size = new System.Drawing.Size(307, 140);
            this.L_Value.TabIndex = 1;
            this.L_Value.Text = "kjvn erkjnekjnvekjn vkdsjn vkj kjs nkejn kjb grfgfskjhdhbg ikhjs";
            this.L_Value.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.L_Value);
            this.panel1.Location = new System.Drawing.Point(13, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 140);
            this.panel1.TabIndex = 2;
            // 
            // AutoToolErrorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 203);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.L_Nazwa);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 250);
            this.Name = "AutoToolErrorInfo";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AutoToolErrorInfo";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_Nazwa;
        private System.Windows.Forms.Label L_Value;
        private System.Windows.Forms.Panel panel1;
    }
}