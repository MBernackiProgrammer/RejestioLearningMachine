
namespace AutomationTool
{
    partial class TaskForm
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.L_Percent = new System.Windows.Forms.Label();
            this.L_TimeLeft = new System.Windows.Forms.Label();
            this.L_Downloaded = new System.Windows.Forms.Label();
            this.L_Time = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 51);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(284, 29);
            this.progressBar1.TabIndex = 0;
            // 
            // L_Percent
            // 
            this.L_Percent.AutoSize = true;
            this.L_Percent.Location = new System.Drawing.Point(302, 51);
            this.L_Percent.Name = "L_Percent";
            this.L_Percent.Size = new System.Drawing.Size(49, 20);
            this.L_Percent.TabIndex = 1;
            this.L_Percent.Text = "100 %";
            // 
            // L_TimeLeft
            // 
            this.L_TimeLeft.AutoSize = true;
            this.L_TimeLeft.Location = new System.Drawing.Point(12, 96);
            this.L_TimeLeft.Name = "L_TimeLeft";
            this.L_TimeLeft.Size = new System.Drawing.Size(110, 20);
            this.L_TimeLeft.TabIndex = 2;
            this.L_TimeLeft.Text = "Pozostały czas :";
            // 
            // L_Downloaded
            // 
            this.L_Downloaded.AutoSize = true;
            this.L_Downloaded.Location = new System.Drawing.Point(12, 120);
            this.L_Downloaded.Name = "L_Downloaded";
            this.L_Downloaded.Size = new System.Drawing.Size(122, 20);
            this.L_Downloaded.TabIndex = 3;
            this.L_Downloaded.Text = "Pobrano : 0 zdjęć";
            this.L_Downloaded.Click += new System.EventHandler(this.L_Downloaded_Click);
            // 
            // L_Time
            // 
            this.L_Time.AutoSize = true;
            this.L_Time.Location = new System.Drawing.Point(13, 144);
            this.L_Time.Name = "L_Time";
            this.L_Time.Size = new System.Drawing.Size(124, 20);
            this.L_Time.TabIndex = 4;
            this.L_Time.Text = "Mineło : 0 sekund";
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 176);
            this.Controls.Add(this.L_Time);
            this.Controls.Add(this.L_Downloaded);
            this.Controls.Add(this.L_TimeLeft);
            this.Controls.Add(this.L_Percent);
            this.Controls.Add(this.progressBar1);
            this.Name = "TaskForm";
            this.Text = "TaskForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Label L_Percent;
        public System.Windows.Forms.Label L_TimeLeft;
        public System.Windows.Forms.Label L_Downloaded;
        public System.Windows.Forms.Label L_Time;
    }
}