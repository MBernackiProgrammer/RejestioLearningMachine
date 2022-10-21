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

namespace AutomationTool.Helpers
{
    public class StartCut
    {
        Label Percent;
        Label TimeLeft;
        Label DownloadedPhotos;
        Label Started;
        ProgressBar ProcessBar;
        Form InfoForm;

        DateTime StartTime;

        Action FuncToDo;
        public StartCut(Label LPercent, Label LTimeLeft, Label LDownloadedPhotos, Label LStarted, ProgressBar LProgressBar, Form LInfoForm, Action LFuncToDo)
        {
            Percent = LPercent;
            TimeLeft = LTimeLeft;
            DownloadedPhotos = LDownloadedPhotos;
            Started = LStarted;
            ProcessBar = LProgressBar;
            StartTime = DateTime.Now;
            InfoForm = LInfoForm;
            FuncToDo = LFuncToDo;
            CutPhotos();
        }

        private void CutPhotos()
        {
            string[] cos = Directory.GetFiles("C:\\Users\\Mateusz Bernacki\\Desktop\\DownloadedFotos\\");

            int ID = 0;
            foreach (string Paths in cos)
            {

                string[] spitcon = Paths.Split('.');
                string end = spitcon.Last();

                if (end == "jpg" || end == "JPEG" || end == "PNG")
                {
                    resizeImage(500, 250, Paths);

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
                //pictureBox1.Image = resizeImage(150, 50, Paths);


            }
            InfoForm.Invoke((MethodInvoker)(() => InfoForm.Close()));
            if (FuncToDo != null)
            {
                FuncToDo();
            }

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

            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                         imgPhoto.VerticalResolution);

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
