// Copyright Mateusz Bernacki. All Rights Reserved.
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using HtmlAgilityPack;
using System.Drawing.Imaging;

using AutomationTool.Settings;

namespace AutomationTool.Helpers
{
    public class StartCut
    {
        //Obiekt klasy Label, odpowiadający za wyświetlanie (jako liczba), ile jest procent ukończenia operacji
        /// <summary>
        /// Odpowiada za napis koło progressbar'u na InfoFormie
        /// </summary>
        Label Percent;

        //Odpowiada za wyświetlenia ile czasu pozostało do zakończenia operacji 
        /// <summary>
        /// Obiekt klasy Label, odpowiadający za wyświetlania ile czasu pozostało do zakończenia operacji
        /// </summary>
        Label TimeLeft;

        // Odpowiada za wyświetlanie ile pobrano zdjęć 
        /// <summary>
        /// Obiekt klasy Label, który służy do wyświerlania ilości pobranych zdjęć 
        /// </summary>
        Label DownloadedPhotos;

        //Odpowiada za wyświetlanie czasu, ile upłynęło od rozpoczęcia operacji 
        /// <summary>
        /// Obiekt klasy Label, który wyświetla ile sekund mineło od rozpoczęcia operacji 
        /// </summary> 
        Label Started;

        // Odpowiada za wyświetlania progresbaru 
        /// <summary>
        /// Obiekt paska progresu na InfoForm'ie (zespawnowanego na wątku głównym)
        /// </summary>
        ProgressBar ProcessBar;

        // Odpowiada za info form (za ten co zostaje wyświetlony po uruchomieniu operacji)
        /// <summary>
        /// Jest to obiekt zespawnowanego informatora o czasie itp. odnośnie operacji
        /// </summary>
        Form InfoForm;

        // Ścieżka która została wybrana wybrana do sprawdzania plików(na samym początku operacji na wątku głównym)
        /// <summary>
        /// Ścieżka operacji na plikach 
        /// </summary>
        string SavePath;

        //Tutaj są operacje, które mają zostać wykonane
        /// <summary>
        /// Klasa przechowuje listę ToDo, opisaną bool'ami 
        /// </summary>
        WhatDo WhatToDo;

        // Obiekt klasy, która zajmuje się przechowywaniem obiektów innych klas, które później będą edytowane za pomocą invok'ów
        /// <summary>
        /// Dane z wątku głównego ap label'ów, które później są edytowane 
        /// </summary>
        FormDataConstructor DataContructor;

        // Wykożystywana jest ta zmienna do określanie ile trwa już proces i ile będzie twać
        /// <summary>
        /// Data rozpoczęcia danej operacji
        /// </summary>
        DateTime StartTime;

        Size ToSetSize = new Size(300, 150);

        public StartCut(FormDataConstructor LDataContructor)
        {
            Percent = LDataContructor.InfoForm.L_Percent;
            TimeLeft = LDataContructor.InfoForm.L_TimeLeft;
            DownloadedPhotos = LDataContructor.InfoForm.L_Downloaded;
            Started = LDataContructor.InfoForm.L_Time;
            ProcessBar = LDataContructor.InfoForm.progressBar1;
            StartTime = DateTime.Now;
            InfoForm = LDataContructor.InfoForm;
            DataContructor = LDataContructor;
            SavePath = LDataContructor.FolderPath; 

            DataContructor.InfoForm.Invoke((MethodInvoker)(() => DataContructor.InfoForm.Text = "Docinanie zdjęć"));
            CutPhotos();
        }

        public StartCut(FormDataConstructor LDataContructor, Size LToSetSize)
        {
            Percent = LDataContructor.InfoForm.L_Percent;
            TimeLeft = LDataContructor.InfoForm.L_TimeLeft;
            DownloadedPhotos = LDataContructor.InfoForm.L_Downloaded;
            Started = LDataContructor.InfoForm.L_Time;
            ProcessBar = LDataContructor.InfoForm.progressBar1;
            StartTime = DateTime.Now;
            InfoForm = LDataContructor.InfoForm;
            DataContructor = LDataContructor;
            SavePath = LDataContructor.FolderPath;

            ToSetSize = LToSetSize;

            DataContructor.InfoForm.Invoke((MethodInvoker)(() => DataContructor.InfoForm.Text = "Docinanie zdjęć"));
            CutPhotos();
        }

        private void CutPhotos()
        {
            string[] cos = Directory.GetFiles(SavePath + "\\");

            int ID = 0;
            foreach (string Paths in cos)
            {

                string[] spitcon = Paths.Split('.');
                string end = spitcon.Last();

                if (end == "jpg" || end == "JPEG" || end == "PNG")
                {

                    resizeImage(ToSetSize.Width, ToSetSize.Height, Paths);

                    int percent = (int)((float)ID / (float)cos.Length * 100);
                    double seconds = (DateTime.Now - StartTime).TotalSeconds;

                    double up = (double)cos.Length * seconds;
                    double down = ID;
                    double ileSekund = up / down;
                    double ileJeszczeSekund = StartTime.Second + ileSekund - DateTime.Now.Second;
                    double ileMin = ileSekund / 60;


                    Percent.Invoke((MethodInvoker)(() => Percent.Text = percent + " %"));

                    TimeLeft.Invoke((MethodInvoker)(() => TimeLeft.Text = "Pozostało jeszcze : " + (int)ileMin + " minut"));

                    DownloadedPhotos.Invoke((MethodInvoker)(() => DownloadedPhotos.Text = "Przetworzono : " + ID + "zdjęć, zostało " + (ID - cos.Length) + " zdjęć"));

                    ProcessBar.Invoke((MethodInvoker)(() => ProcessBar.Value = percent));

                    Started.Invoke((MethodInvoker)(() => Started.Text = "Mineło : " + (int)seconds + " sekund"));

                    ID = ID + 1;
                }
                else
                {
                    File.Delete(Paths);
                }
            }

            DataContructor.WhatToDo.CutPhotos = false;

            Runner.WhatNow(DataContructor);

            InfoForm.Invoke((MethodInvoker)(() => InfoForm.Close()));
        }

        public Image resizeImage(int newWidth, int newHeight, string stPhotoPath)
        {
            Image imgPhoto = Image.FromFile(stPhotoPath);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            //Consider vertical pics
            if (sourceWidth < sourceHeight)
            {
                int buff = newWidth;

                newWidth = newHeight;
                newHeight = buff;
            }

            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float nPercent = 0, nPercentW = 0, nPercentH = 0;

            nPercentW = ((float)newWidth / (float)sourceWidth);
            nPercentH = ((float)newHeight / (float)sourceHeight);

            nPercent = nPercentH;
            destX = System.Convert.ToInt32((newWidth -
                      (sourceWidth * nPercent)) / 2);

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(newWidth, newHeight);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Black);
            grPhoto.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            imgPhoto.Dispose();

            bmPhoto.Save(stPhotoPath);
            return bmPhoto;
        }

    }
}