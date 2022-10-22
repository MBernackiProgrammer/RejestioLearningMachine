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
       
        void MyMethod(object param, object label)
        {
            TaskForm xos;
            xos = (TaskForm)param;

            xos.UpdatePercent(100);
            xos.UpdateTime(10);

            Label l = (Label)label;
            l.Text = "xd";
        }

        private void CheckIsDubled()
        {
            CutFotos();
        }

        private void CutFotos()
        {
            
            
        }

        private void Segregate()
        {

        }
        private void btn_StartProcessing_Click(object sender, EventArgs e)
        {
            //DownloadImages();
            ChangeDisplayForm(new AutomationTool.AllSettings(this), this.panel2);



        }

        private void btn_OnlyInstall_Click(object sender, EventArgs e)
        {
            //DownloadImages();
        }

        private void btn_ChceckIsDubled_Click(object sender, EventArgs e)
        {
            CheckIsDubled();
        }

        private void btn_CutOnly_Click(object sender, EventArgs e)
        {

        }

        private void btn_ChangeNames_Click(object sender, EventArgs e)
        {

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

                        thrProcess.Start();
                        nowy.Show();
                        break;
                    }

            }
        }
    }
}

    

