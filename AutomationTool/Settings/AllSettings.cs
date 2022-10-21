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

namespace AutomationTool
{
    public partial class AllSettings : Form
    {
        public AllSettings()
        {
            InitializeComponent();
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
                    DataConstructor.Percent = nowy.L_Percent;
                    DataConstructor.TimeLeft = nowy.L_TimeLeft;
                    DataConstructor.Downloaded = nowy.L_Downloaded;
                    DataConstructor.Time = nowy.L_Time;
                    DataConstructor.Progres = nowy.progressBar1;
                    DataConstructor.InfoForm = nowy;
                    DataConstructor.WhatToDo = WhatToDo;
                    DataConstructor.FolderPath = tb_Path.Text;


                    //Tutaj rozpoczyna się proces 
                    
                    Thread thrProcess = new Thread(
                        () =>
                        {
                            StartPhotoDownload pr = new StartPhotoDownload(DataConstructor);
                        });

                    thrProcess.Start();
                    nowy.Show();
                }
                else
                {
                    //Powiadomienie o błędzie // ścieżka folderu jest niepoprawna 
                }
            }
            else
            {
                //Powiadomienie o błędzie // conajmniej jedna opcja musi być zaznaczona
            }
        }
    }
}
