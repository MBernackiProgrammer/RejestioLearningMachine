using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AutomationTool.Settings;
using AutomationTool.Helpers;
using AutomationTool.ErrorInfo;
using System.IO;

namespace AutomationTool.Settings
{
    public partial class CutOnly : Form
    {
        Form1 SpawnBy;
        public CutOnly(Form1 LSpawnBy)
        {
            InitializeComponent();
            SpawnBy = LSpawnBy;
        }

        private void btn_Browace_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            tb_BrowacePath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btn_Cut_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(tb_BrowacePath.Text))
            {
                if (tb_X.Text != "" && tb_Y.Text != "")
                {
                    WhichFun Fun = WhichFun.Scaler;

                    WhatDo WhatToDo = new WhatDo();
                    WhatToDo.CutPhotos = true;

                    FormDataConstructor Konstruktor = new FormDataConstructor();

                    Konstruktor.WhatToDo = WhatToDo;
                    Konstruktor.FolderPath = tb_BrowacePath.Text;
                    Konstruktor.StartForm = SpawnBy;

                    int test1 = int.Parse(tb_X.Text);
                    Size ChangeTo = new Size(int.Parse(tb_X.Text), int.Parse(tb_Y.Text));

                    Runner.RunMainThreadFunc(Fun, Konstruktor, ChangeTo);
                }
                else
                {
                    ErrorInfoSpawner.PrintError("Brak rozmiaru", "Użytkowniku, nie ustawiłeś rozmiaru, na jaki ma być zmieniony rozmiar zdjęcia");
                }
            }
            else
            {
                ErrorInfoSpawner.PrintError("Zła ścieżka", "Użytkowniku, nie podałeś złą, ścieżkę pliku, proszę zmień ją");
            } 
        }

        private void CutOnly_Load(object sender, EventArgs e)
        {

        }
    }
}
