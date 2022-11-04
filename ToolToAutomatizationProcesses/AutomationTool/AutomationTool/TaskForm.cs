// Copyright Mateusz Bernacki. All Rights Reserved.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutomationTool
{
    public partial class TaskForm : Form
    {
        
        public TaskForm()
        {
            InitializeComponent();
        }

        public void UpdatePercent(int value)
        {

            progressBar1.Value = value;
            //label1.Text = "cos";
        }

        public void UpdateTime(int value)
        {
            L_Time.Text = value.ToString();
        }

        public void UpdateNumberOfFiles(int now)
        {
            L_Downloaded.Text = now.ToString();
        }

        private void L_Downloaded_Click(object sender, EventArgs e)
        {
        }
    }
}
