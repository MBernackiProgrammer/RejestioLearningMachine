using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using AutomationTool.Helpers;

using AutomationTool.ErrorInfo;

namespace AutomationTool.Settings
{
    public partial class ChangeName : Form
    {
        Form1 SpawnedBy;
        public ChangeName(Form1 LSpawnedBy)
        {
            InitializeComponent();
            SpawnedBy = LSpawnedBy;
        }

        private void btn_Browace_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            tb_Browace.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btn_Strart_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(tb_Browace.Text))
            {
                WhichFun Fun = WhichFun.Rename;

                WhatDo WhatToDo = new WhatDo();
                WhatToDo.ChangeNames = true;

                FormDataConstructor Konstruktor = new FormDataConstructor();

                Konstruktor.WhatToDo = WhatToDo;
                Konstruktor.FolderPath = tb_Browace.Text;
                Konstruktor.StartForm = SpawnedBy;
                Konstruktor.PreForm = tb_PreForm.Text;

                Runner.RunMainThreadFunc(Fun, Konstruktor);
            }
            else
            {
                ErrorInfoSpawner.PrintError("Błąd ścieżki", "Ścieżka jes nie poprawna, wpisz ją poprawnie");
            }
        }
    }
}
