using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AutomationTool.Helpers;

namespace AutomationTool.Settings
{
    public partial class IsDublet : Form
    {
        Form1 SpawnBy;
        public IsDublet(Form1 LSpawnedBy)
        {
            InitializeComponent();
            SpawnBy = LSpawnedBy;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            tb_Browarce.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WhichFun Fun = WhichFun.DoubleSearcer;

            WhatDo WhatToDo = new WhatDo();
            WhatToDo.SearchDubel = true;

            FormDataConstructor Konstruktor = new FormDataConstructor();

            Konstruktor.WhatToDo = WhatToDo;
            Konstruktor.FolderPath = tb_Browarce.Text;
            Konstruktor.StartForm = SpawnBy;

            Runner.RunMainThreadFunc(Fun, Konstruktor);
        }
    }
}
