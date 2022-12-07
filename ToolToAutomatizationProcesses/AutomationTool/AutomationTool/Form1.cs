// Copyright Mateusz Bernacki. All Rights Reserved.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Drawing.Imaging;

using AutomationTool.Helpers;
using AutomationTool.Settings;

namespace AutomationTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Zmienia wyświetlany form w oknie głównym 
        /// </summary>
        /// <param name="ChangeTo"></param>
        /// <param name="ChangeIn"></param>
        void ChangeDisplayForm(Form ChangeTo, Panel ChangeIn)
        {
            ChangeTo.TopLevel = false;
            ChangeTo.FormBorderStyle = FormBorderStyle.None;
            ChangeTo.Dock = DockStyle.Fill;
            ChangeIn.Controls.Add(ChangeTo);
            ChangeIn.Tag = ChangeTo;
            ChangeTo.BringToFront();
            ChangeTo.Show();
        }
       
        /// <summary>
        /// Przełącza boczny form na ustawienia całego procesu 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_StartProcessing_Click(object sender, EventArgs e)
        {
            //DownloadImages();
            ChangeDisplayForm(new AutomationTool.AllSettings(this), this.panel2);
        }

        /// <summary>
        /// Przełącza form boczny na ustawienia tylko pobierania 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OnlyInstall_Click(object sender, EventArgs e)
        {
            //DownloadImages();
            ChangeDisplayForm(new AutomationTool.OnlyInstallSettings(this), this.panel2);
        }

        /// <summary>
        /// Przełącza na ustawienia formu, który sprawdza czy zdjęcia są zdublowane
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ChceckIsDubled_Click(object sender, EventArgs e)
        {
            ChangeDisplayForm(new AutomationTool.Settings.IsDublet(this), this.panel2);
        }

        /// <summary>
        /// Przełącza na ustawienia formu, który obcina zdjęcia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CutOnly_Click(object sender, EventArgs e)
        {
            ChangeDisplayForm(new AutomationTool.Settings.CutOnly(this), this.panel2);
        }
        
        /// <summary>
        /// Przełącza na ustawienia formu, który zmienia nazwy plików
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ChangeNames_Click(object sender, EventArgs e)
        {
            ChangeDisplayForm(new AutomationTool.Settings.ChangeName(this), this.panel2);
        }

        /// <summary>
        /// Funkcja zaczyna proces, który zostaje podany w Which
        /// </summary>
        /// <param name="Which"></param>
        /// <param name="RunInfo"></param>
        public void RunFunction(WhichFun Which, FormDataConstructor RunInfo)
        {
            //Wszystkie rozpoczęcia są tworzone na nowym wątku, aby główne okno było responsywne 
            //oraz, aby zespawnowane okno również było responsywne 
            switch(Which)
            {
                //Zaczyna proces sprawdzania zdublowania zdjęć
                case WhichFun.DoubleSearcer :
                    {
                        TaskForm nowy = new TaskForm();
                        RunInfo.InfoForm = nowy;

                        Thread thrProcess = new Thread(
                            () =>
                            {
                                DoubleScaner pr = new DoubleScaner(RunInfo);
                            });
                        thrProcess.Priority = ThreadPriority.Highest;
                        thrProcess.Start();
                        nowy.Show();
                        break;
                    }

                //Zaczyna proces pobierania zdjęć
                case WhichFun.Download:
                    {
                        TaskForm nowy = new TaskForm();
                        RunInfo.InfoForm = nowy;

                        Thread thrProcess = new Thread(
                            () =>
                            {
                                StartPhotoDownload pr = new StartPhotoDownload(RunInfo);
                            });
                        thrProcess.Priority = ThreadPriority.Highest;
                        thrProcess.Start();
                        nowy.Show();
                        break;
                    }

                //Zaczyna proces zmieniania nazw zdjęć
                case WhichFun.Rename:
                    {
                        TaskForm nowy = new TaskForm();
                        RunInfo.InfoForm = nowy;

                        Thread thrProcess = new Thread(
                            () =>
                            {
                                Renamer pr = new Renamer(RunInfo);
                            });
                        thrProcess.Priority = ThreadPriority.Highest;
                        thrProcess.Start();
                        nowy.Show();
                        break;
                    }

                //Zaczyna proces skalowania zdjęć
                case WhichFun.Scaler:
                    {
                        TaskForm nowy = new TaskForm();
                        RunInfo.InfoForm = nowy;

                        Thread thrProcess = new Thread(
                            () =>
                            {
                                StartCut pr = new StartCut(RunInfo);
                            });
                        thrProcess.Priority = ThreadPriority.Highest;
                        thrProcess.Start();
                        nowy.Show();
                        break;
                    }

            }
        }

        /// <summary>
        /// Przeciążenie funkcji RunFunction, aby móc pobierać tylko zdjęcia
        /// </summary>
        /// <param name="Which"></param>
        /// <param name="RunInfo"></param>
        /// <param name="ListaSlow"></param>
        public void RunFunction(WhichFun Which, FormDataConstructor RunInfo, List<string> ListaSlow)
        {
            switch (Which)
            {
                case WhichFun.Download:
                    {
                        TaskForm nowy = new TaskForm();
                        RunInfo.InfoForm = nowy;

                        Thread thrProcess = new Thread(
                            () =>
                            {
                                StartPhotoDownload pr = new StartPhotoDownload(RunInfo, ListaSlow);
                            });

                        thrProcess.Start();
                        nowy.Show();
                        break;
                    }
            }
        }

        /// <summary>
        /// Przeciążenie funkcji RunFunction, aby móc scalować tylko zdjęcia
        /// </summary>
        /// <param name="Which"></param>
        /// <param name="RunInfo"></param>
        /// <param name="ListaSlow"></param>
        public void RunFunction(WhichFun Which, FormDataConstructor RunInfo, Size toSize)
        {
            switch(Which)
            {
                case WhichFun.Scaler:
                    {
                        TaskForm nowy = new TaskForm();
                        RunInfo.InfoForm = nowy;

                        Thread thrProcess = new Thread(
                            () =>
                            {
                                StartCut pr = new StartCut(RunInfo, toSize);
                            });
                        thrProcess.Priority = ThreadPriority.Highest;
                        thrProcess.Start();
                        nowy.Show();
                        break;
                    }

            }
        }

    }
}

    

