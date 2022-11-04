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

        Label Percent;
        Label TimeLeft;
        Label PhotosLeft;
        Label Started;
        ProgressBar ProcessBar;
        Form InfoForm;
        FormDataConstructor DataContructor;
        string EditPath;


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
