using System;
using System.Windows.Forms;
using AutomationTool.Settings;
using System.IO;

namespace AutomationTool.Helpers
{
    public class DoubleScaner
    {
        // Odpowiada za napis koło progressbar'u 
        Label Percent;

        // Odpowiada za wyświetlenia ile czasu pozostało do zakończenia operacji 
        Label TimeLeft;

        // Odpowiada za wyświetlanie ile pobrano zdjęć 
        Label DownloadedPhotos;

        //Odpowiada za wyświetlanie czasu, ile upłynęło od rozpoczęcia operacji 
        Label Started;

        // Odpowiada za wyświetlania progresbaru 
        ProgressBar ProcessBar;

        // Odpowiada za info form (za ten co zostaje wyświetlony po uruchomieniu operacji)
        Form InfoForm;

        // Ścieżka która została wybrana (do zmiany zdjęć)
        string SavePath;

        //Tutaj są operacje, które mają zostać wykonane
        WhatDo WhatToDo;

        // Obiekt klasy, która zajmuje się zapisem najważniejszych informacji 
        FormDataConstructor DataContructor;

        // Data rozpoczęcia operacji 
        DateTime StartTime;

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
            }
            catch
            {

            }

            CheckIsSame();
        }

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
