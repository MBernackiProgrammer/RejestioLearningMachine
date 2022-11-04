using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;
using System.Threading;

using AutomationTool.Helpers;
using AutomationTool.Settings;
using AutomationTool.ErrorInfo;

namespace AutomationTool
{
    public partial class AllSettings : Form
    {
        Form1 SpawnedBy;
        public AllSettings(Form1 LSpawnedBy)
        {
            InitializeComponent();

            SpawnedBy = LSpawnedBy;
        }

        private void btn_Browace_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            tb_Path.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btn_Ready_Click(object sender, EventArgs e)
        {
            if (cb_CheckThatDubled.Checked == true || cb_Install.Checked == true || cb_ScalePhotos.Checked == true || cb_Sort.Checked == true)
            {
                if(Directory.Exists(tb_Path.Text))
                {
                    TaskForm nowy = new TaskForm();

                    WhatDo WhatToDo = new WhatDo();
                    WhatToDo.Downloading = cb_Install.Checked;
                    WhatToDo.SearchDubel = cb_CheckThatDubled.Checked;
                    WhatToDo.CutPhotos = cb_ScalePhotos.Checked;
                    WhatToDo.ChangeNames = cb_Sort.Checked;

                    FormDataConstructor DataConstructor = new FormDataConstructor();
                    DataConstructor.InfoForm = nowy;
                    DataConstructor.WhatToDo = WhatToDo;
                    DataConstructor.FolderPath = tb_Path.Text;
                    DataConstructor.StartForm = SpawnedBy;
                    DataConstructor.PreForm = tb_PreForm.Text;

                    WhichFun Fun = WhichFun.Download;
                    //Tutaj rozpoczyna się proces 

                    Runner.RunMainThreadFunc(Fun, DataConstructor);
                }
                else
                {
                    //Powiadomienie o błędzie // ścieżka folderu jest niepoprawna 
                    ErrorInfoSpawner.PrintError("Błąd ścieżki", "Nie znaleziono ścieżki, popraw ją, a następnie znów rozpocznij operację");
                }
            }
            else
            {
                //Powiadomienie o błędzie // conajmniej jedna opcja musi być zaznaczona
                ErrorInfoSpawner.PrintError("Brak zaznaczonych zadań", "Conajmniej jedna operacja musi zostać zaznaczona, zaznacz conajmniej jedno zadanie do wykonania");
            }
        }
    }
}
