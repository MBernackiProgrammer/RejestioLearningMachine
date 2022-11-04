// Copyright Mateusz Bernacki. All Rights Reserved.
using System;
using System.Windows.Forms;
using AutomationTool.Settings;
using System.IO;
using AutomationTool.ErrorInfo;

namespace AutomationTool.Helpers
{
    /// <summary>
    /// Zadaniem klasy jest sprawdzanie tego, czy plik są takie same
    /// </summary>
    public class DoubleScaner
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

        /// <summary>
        /// Konstruktor klasy DoubleScaner. Klasa odpowiada za sprawdzanie czy zdjęcia są takie dame 
        /// </summary>
        /// <param name="LDataContructor">Tutaj zawarte są najważniejsze informacje, ap </param>
        public DoubleScaner(FormDataConstructor LDataContructor)
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

            try
            {
                DataContructor.InfoForm.Invoke((MethodInvoker)(() => DataContructor.InfoForm.Text = "Docinanie zdjęć"));
                CheckIsSame();
            }
            catch
            {
                ErrorInfoSpawner.PrintError("Błąd", "Doszło do błędu, proszę rozpocznij operację od początku");
            } 
        }

        /// <summary>
        /// Metoda zarządzająca sprawdzaniem zdjeć
        /// Zmienia statystyki na 
        /// 
        /// </summary>
        private void CheckIsSame()
        {
            string SavePath = "C:\\Users\\Mateusz Bernacki\\Documents\\kjvhsbk";
            string[] cos = Directory.GetFiles(SavePath);

            int ID = 0;
            foreach (string Paths in cos)
            {
                foreach (string Paths2 in cos)
                {
                    Checker(Paths, Paths2);
                }

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

            DataContructor.WhatToDo.SearchDubel = false;

            Runner.WhatNow(DataContructor);

            InfoForm.Invoke((MethodInvoker)(() => InfoForm.Close()));
        }

        void Checker(string ImgChecking, string ImgToCheck)
        {
            if (File.Exists(ImgToCheck) && File.Exists(ImgChecking))
            {
                if (ImgChecking != ImgToCheck)
                {
                    int idNow = 0;
                    int isSame = 0;
                    byte[] imgFirst = File.ReadAllBytes(ImgChecking);
                    byte[] imgSecond = File.ReadAllBytes(ImgToCheck);

                    //label1.Text = label1.Text + " first : " + imgFirst.Length.ToString() + " secondnd : " + imgSecond.Length.ToString();
                    if (imgFirst.Length == imgSecond.Length)
                    {
                        foreach (byte bajt in imgFirst)
                        {
                            if (bajt == imgSecond[idNow])
                            {
                                isSame = isSame + 1;
                            }
                            idNow = idNow + 1;
                        }

                        float percent = (float)isSame / (float)idNow;
                        if (percent > 0.1)
                        {
                            File.Delete(ImgToCheck);
                        }
                    }
                }
            }

        }
    }
}
