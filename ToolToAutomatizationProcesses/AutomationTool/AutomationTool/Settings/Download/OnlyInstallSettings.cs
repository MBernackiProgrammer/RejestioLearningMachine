using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AutomationTool.Helpers;
using AutomationTool.Settings;

namespace AutomationTool
{
    public partial class OnlyInstallSettings : Form
    {
        Form1 SpawnBy;
        public OnlyInstallSettings(Form1 LSpawnedBy)
        {
            InitializeComponent();
            SpawnBy = LSpawnedBy;
        }

        private void btn_LaunchFolderBrowace_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            tb_Browace.Text = folderBrowserDialog1.SelectedPath;
        }

        private void ch_OwnTitles_CheckedChanged(object sender, EventArgs e)
        {
            tb_OwnTitles.Enabled = ch_OwnTitles.Checked;
        }

        private void btn_Download_Click(object sender, EventArgs e)
        {
            WhichFun Fun = WhichFun.Download;

            WhatDo WhatToDo = new WhatDo();
            WhatToDo.Downloading = true;
            
            FormDataConstructor Konstruktor = new FormDataConstructor();

            Konstruktor.WhatToDo = WhatToDo;
            Konstruktor.FolderPath = tb_Browace.Text;
            Konstruktor.StartForm = SpawnBy;

            string[] list = tb_OwnTitles.Text.Split(',');

            List<string> ListaSlow = new List<string>();

            foreach (string TabWord in list)
            {
                ListaSlow.Add(TabWord);
            }

            Runner.RunMainThreadFunc(Fun, Konstruktor, ListaSlow);
        }
    }
}
