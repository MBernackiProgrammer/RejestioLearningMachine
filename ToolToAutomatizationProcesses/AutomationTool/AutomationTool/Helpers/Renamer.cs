// Copyright Mateusz Bernacki. All Rights Reserved.
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;




namespace AutomationTool.Helpers
{
    public class Renamer
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
        Label PhotosLeft;

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

        // Obiekt klasy, która zajmuje się przechowywaniem obiektów innych klas, które później będą edytowane za pomocą invok'ów
        /// <summary>
        /// Dane z wątku głównego ap label'ów, które później są edytowane 
        /// </summary>
        FormDataConstructor DataContructor;

        // Ścieżka która została wybrana wybrana do sprawdzania plików(na samym początku operacji na wątku głównym)
        /// <summary>
        /// Ścieżka operacji na plikach 
        /// </summary>
        string EditPath;

        // Wykożystywana jest ta zmienna do określanie ile trwa już proces i ile będzie twać
        /// <summary>
        /// Data rozpoczęcia danej operacji
        /// </summary>
        DateTime StartTime;

        public Renamer(FormDataConstructor LDataContructor)
        {
            Percent = LDataContructor.InfoForm.L_Percent;
            TimeLeft = LDataContructor.InfoForm.L_TimeLeft;
            PhotosLeft = LDataContructor.InfoForm.L_Downloaded;
            Started = LDataContructor.InfoForm.L_Time;
            ProcessBar = LDataContructor.InfoForm.progressBar1;
            StartTime = DateTime.Now;
            InfoForm = LDataContructor.InfoForm;
            DataContructor = LDataContructor;
            EditPath = LDataContructor.FolderPath;

            DataContructor.InfoForm.Invoke((MethodInvoker)(() => DataContructor.InfoForm.Text = "Edycja ścieżki"));
            UpDateFiles();


        }
        

        int id = 0;
        void UpDateFiles()
        {
            string[] cos = Directory.GetFiles(EditPath);


            foreach (string xd in cos)
            {
                string[] spitcon = xd.Split('.');
                string end = spitcon.Last();
                
                if (end == "jpg" || end == "JPEG" || end == "PNG")
                {
                    if(!File.Exists(xd))
                    {
                        File.Move(xd, EditPath + "\\" + DataContructor.PreForm + id.ToString() + "." + end);
                    }
                    
                }
                else
                {
                    File.Delete(xd);
                }
                id = id + 1;

                int percent = (int)((float)id / (float)cos.Length * 100);
                double seconds = (DateTime.Now - StartTime).TotalSeconds;

                double up = (double)cos.Length * seconds;
                double down = id;
                double ileSekund = up / down;
                double ileJeszczeSekund = StartTime.Second + ileSekund - DateTime.Now.Second;
                double ileMin = ileSekund / 60;

                ProcessBar.Invoke((MethodInvoker)(() => ProcessBar.Value = percent));
                Percent.Invoke((MethodInvoker)(() => Percent.Text = (int)percent + " %"));
                PhotosLeft.Invoke((MethodInvoker)(() => PhotosLeft.Text = "Pozostało do przetworzenia " + (int)(cos.Length - id) + " zdjęć"));
                Started.Invoke((MethodInvoker)(() => PhotosLeft.Text = "Mineło : " + (StartTime - DateTime.Now).TotalSeconds + " sekund"));
            }

            InfoForm.Invoke((MethodInvoker)(() => InfoForm.Close()));
        }
    }
}
