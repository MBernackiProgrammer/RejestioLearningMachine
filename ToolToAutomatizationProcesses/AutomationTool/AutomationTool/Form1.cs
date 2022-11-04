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
       
        private void btn_StartProcessing_Click(object sender, EventArgs e)
        {
            //DownloadImages();
            ChangeDisplayForm(new AutomationTool.AllSettings(this), this.panel2);
        }

        private void btn_OnlyInstall_Click(object sender, EventArgs e)
        {
            //DownloadImages();
            ChangeDisplayForm(new AutomationTool.OnlyInstallSettings(this), this.panel2);
        }

        private void btn_ChceckIsDubled_Click(object sender, EventArgs e)
        {
            ChangeDisplayForm(new AutomationTool.Settings.IsDublet(this), this.panel2);
        }

        private void btn_CutOnly_Click(object sender, EventArgs e)
        {
            ChangeDisplayForm(new AutomationTool.Settings.CutOnly(this), this.panel2);
        }

        private void btn_ChangeNames_Click(object sender, EventArgs e)
        {
            ChangeDisplayForm(new AutomationTool.Settings.ChangeName(this), this.panel2);
        }

        public void RunFunction(WhichFun Which, FormDataConstructor RunInfo)
        {
            switch(Which)
            {
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

    

