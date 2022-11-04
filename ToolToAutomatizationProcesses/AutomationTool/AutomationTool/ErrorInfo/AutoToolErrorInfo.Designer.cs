
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
            this.SuspendLayout();
            // 
            // L_Nazwa
            // 
            this.L_Nazwa.AutoSize = true;
            this.L_Nazwa.Location = new System.Drawing.Point(13, 13);
            this.L_Nazwa.Name = "L_Nazwa";
            this.L_Nazwa.Size = new System.Drawing.Size(50, 20);
            this.L_Nazwa.TabIndex = 0;
            this.L_Nazwa.Text = "label1";
            // 
            // L_Value
            // 
            this.L_Value.AutoSize = true;
            this.L_Value.Location = new System.Drawing.Point(13, 64);
            this.L_Value.Name = "L_Value";
            this.L_Value.Size = new System.Drawing.Size(50, 20);
            this.L_Value.TabIndex = 1;
            this.L_Value.Text = "label1";
            // 
            // AutoToolErrorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 179);
            this.Controls.Add(this.L_Value);
            this.Controls.Add(this.L_Nazwa);
            this.Name = "AutoToolErrorInfo";
            this.Text = "AutoToolErrorInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_Nazwa;
        private System.Windows.Forms.Label L_Value;
    }
}