using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Drawing.Imaging;

namespace AutomationTool.Helpers
{
    class DoTask
    {
    }

    public class StartProcessing
    {
        Label Percent;
        Label TimeLeft;
        Label DownloadedPhotos;
        Label Started;
        ProgressBar ProcessBar;
        Form InfoForm;
        Action FuncToDo;


        List<string> listaSlow = new List<string> { "dog", "car", "truck", "cat", "florida", "road+sign" , "Bus+Stop", "abandon", "Actor", "Advertisement", "Afternoon", "Airport", "Animal", "Apple", "Army" , "Australia", "Balloon", "Banana" , "Battery", "Beach", "Poland", "Food", "Belgium", "Boy", "Branch", "Breakfast", "Brother", "Camera", "Candle", "Car", "Caravan", "Carpet", "Cartoon", "China", "Church", "Crayon", "Crowd", "Daughter", "Death", "Denmark", "Diamond", "Dinner", "Disease", "Doctor", "Dog", "Dream", "Dress", "Easter", "Egg", "Eggplant", "Egypt", "Elephant", "Energy", "Engine", "England", "Evening", "Eye", "Family", "Finland", "Fish", "Flag", "Flower", "Football", "Forest", "Fountain", "France", "Furniture", "Garage", "Gold", "Grass", "Greece", "Guitar", "Hair", "Hamburger", "Helicopter", "Helmet", "Holiday", "Honey", "Horse", "Hospital", "House", "Hydrogen", "Ice", "Insect", "Insurance", "Iron", "Island", "Jackal", "Jelly", "people", "way", "art", "world", "information", "map", "two", "family", "government", "health", "system", "computer", "meat", "year", "thanks", "facebook", "youtube", "amazon", "	weather", "walmart", "google", "wordle", "gmail", "target", "home+depot", "google+translate"
            , "yahoo+mail", "yahoo", "costco", "fox+news", "starbucks", "translate", "instagram", "walgreens", "nba", "mcdonalds", "nfl", "amazon+prime", "cnn", "traductor", "weather+tomorrow", "espn", "lowes", "news", "food", "zillow", "craigslist", "cvs", "ebay", "twitter", "wells+fargo", "usps+tracking", "calculator", "indeed", "etsy", "netflix", "taco+bell", "shein", "astronaut", "macys", "kohls", "youtube+tv", "dollar+tree", "gas+station", "coffee", "roblox", "restaurants", "autozone", "usps", "dominos", "chipotle", "tiempo", "hotmail", "maps", "subway", "motel", "breakfast", "gas", "fedex", "ikea", "linkedin", "music", "person", "reading", "method", "data", "food", "understanding", "theory", "law", "bird", "literature", "problem", "software", "control	", "knowledge", "power", "ability", "economics", "love", "internet", "television", "science", "library", "nature", "fact", "product	", "idea", "temperature", "investment", "area", "society", "activity", "story", "industry", "media", "thing", "oven", "community", "definition", "safety", "quality", "development", "language", "management", "player", "variety", "video", "week", "security", "country", "exam", "movie", "organization", "equipment", "physics",
            "analysis", "policy", "series", "thought", "basis", "boyfriend", "direction", "strategy", "technology", "army", "camera", "freedom", "paper", "environment", "child", "instance", "month", "truth", "marketing", "university", "writing", "article", "department", "difference", "goal", "news", "audience", "fishing", "growth", "income", "marriage", "user", "combination", "failure", "meaning", "medicine", "philosophy", "teacher	", "communication", "night", "chemistry", "disease", "disk", "energy", "nation", "road", "role", "soup", "advertising", "location", "success", "addition", "apartment", "education", "math", "moment", "politics", "attention", "decision", "event", "property", "shopping", "student", "wood", "competition", "distribution", "entertainment", "office", "population", "president", "unit", "category", "context", "cigarette", "introduction", "opportunity", "performance", "driver", "flight", "length", "magazine", "newspaper", "relationship", "teaching", "cell", "dealer", "finding", "lake", "member", "message", "phone", "scene", "appearance", "association", "concept", "customer", "death", "discussion", "housing", "inflation", "insurance", "mood", "woman", "advice", "blood", "effort", "expression",
        "importance", "opinion", "payment", "reality", "responsibility", "situation", "skill", "statement", "wealth", "application", "city", "county", "depth", "estate", "foundation", "grandmother", "heart", "perspective", "photo", "recipe", "studio", "topic", "collection", "depression", "imagination", "passion", "percentage", "resource", "setting", "ad", "agency", "college", "connection", "criticism", "debt", "description", "memory", "patience", "secretary", "solution", "administration", "aspect", "attitude", "director", "personality", "psychology", "recommendation", "response", "selection", "storage", "version", "alcohol", "argument", "complaint", "contract", "emphasis", "highway", "loss", "membership", "possession", "preparation", "steak", "union", "agreement", "cancer", "currency", "employment", "engineering", "entry", "interaction", "mixture", "preference", "region", "republic", "tradition", "virus", "actor", "classroom", "delivery", "device", "difficulty", "drama", "election", "engine", "football", "guidance", "hotel", "owner", "priority", "protection", "suggestion", "tension", "variation", "anxiety", "atmosphere", "awareness", "bath", "bread", "candidate", "climate", "comparison"};

        public StartProcessing(Label LPercent, Label LTimeLeft, Label LDownloadedPhotos, Label LStarted, ProgressBar LProgressBar, Form LInfoForm, Action LFuncToDo)
        {
            Percent = LPercent;
            TimeLeft = LTimeLeft;
            DownloadedPhotos = LDownloadedPhotos;
            Started = LStarted;
            ProcessBar = LProgressBar;
            InfoForm = LInfoForm;
            FuncToDo = LFuncToDo;
            DownloadStart();
        }

        //int percent = 0;
        public void UpdateInfo()
        {
            Percent.Invoke((MethodInvoker)(() => Percent.Text = "Wartosc zmiennej"));
            TimeLeft.Invoke((MethodInvoker)(() => TimeLeft.Text = "Wartosc zmiennej"));
            DownloadedPhotos.Invoke((MethodInvoker)(() => DownloadedPhotos.Text = "Wartosc zmiennej"));
            Started.Invoke((MethodInvoker)(() => Started.Text = "Wartosc zmiennej"));
        }

        DateTime StartTime;
        int idMax = 0;
        public void DownloadStart()
        {
            StartTime = DateTime.Now;

            foreach (string link in listaSlow)
            {
                //listaSlow
                List<string> ImageList = GetAllImages(@"https://www.google.com/search?q=" + link + "&tbm=isch");
                using (WebClient client = new WebClient())
                {
                    for (int i = 1; i < ImageList.Count; i++)
                    {
                        idMax = idMax + 1;
                        client.DownloadFile(new Uri(ImageList[i]), "C:\\Users\\Mateusz Bernacki\\Desktop\\DownloadedFotos\\" + idMax + ".jpg");

                        double seconds = (DateTime.Now - StartTime).TotalSeconds;

                        double up = double.Parse(listaSlow.Count.ToString()) * seconds;
                        double down = idMax / 20;
                        double ileSekund = up / down;
                        double ileJeszczeSekund = StartTime.Second + ileSekund - DateTime.Now.Second;
                        double ileMin = ileSekund / 60;

                        int ileProcent = (int)(idMax / 20 / float.Parse(listaSlow.Count.ToString()) * 100);

                        float cos = idMax / 20 / listaSlow.Count * 100;
                        Percent.Invoke((MethodInvoker)(() => Percent.Text = ileProcent + " %"));

                        TimeLeft.Invoke((MethodInvoker)(() => TimeLeft.Text = "Pozostało jeszcze : " + (int)ileMin + " minut"));

                        DownloadedPhotos.Invoke((MethodInvoker)(() => DownloadedPhotos.Text = "Pobrano : " + idMax + "zdjęć"));

                        ProcessBar.Invoke((MethodInvoker)(() => ProcessBar.Value = ileProcent));

                        Started.Invoke((MethodInvoker)(() => Started.Text = "Mineło : " + (int)seconds + " sekund"));
                    }
                }
            }


            InfoForm.Invoke((MethodInvoker)(() => InfoForm.Close()));

            if (FuncToDo != null)
            {
                FuncToDo();
            }
        }
        public static List<string> GetAllImages(string SearchURL)
        {
            List<string> ImageList = new List<string>();
            WebClient x = new WebClient();

            //string cosx = ;
            string source = x.DownloadString(SearchURL);

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();

            document.LoadHtml(source);

            foreach (var link in document.DocumentNode.Descendants("img").Select(i => i.Attributes["src"]))
            {
                ImageList.Add(link.Value);
            }
            return ImageList;
        }
    }

    public class StartCutOnly
    {
        Label Percent;
        Label TimeLeft;
        Label DownloadedPhotos;
        Label Started;
        ProgressBar ProcessBar;
        Form InfoForm;

        DateTime StartTime;

        Action FuncToDo;
        public StartCutOnly(Label LPercent, Label LTimeLeft, Label LDownloadedPhotos, Label LStarted, ProgressBar LProgressBar, Form LInfoForm, Action LFuncToDo)
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
                    //resizeImage(500, 250, Paths);

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
    }
}
