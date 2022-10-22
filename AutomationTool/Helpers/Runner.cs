using System.Windows.Forms;

namespace AutomationTool.Helpers
{
    public enum WhichFun
    {
        Download, 
        DoubleSearcer, 
        Scaler, 
        Rename
    }
    class Runner
    {
        static public void RunMainThreadFunc(WhichFun Which, FormDataConstructor RunInfo)
        {
            Form1 cos = RunInfo.StartForm;

            cos.Invoke((MethodInvoker)(() => cos.RunFunction(Which, RunInfo)));
        }

        static public void WhatNow(FormDataConstructor DataContructor)
        {
            if (DataContructor.WhatToDo.Downloading == true)
            {
                WhichFun SelsectFunction = WhichFun.Download;
                Runner.RunMainThreadFunc(SelsectFunction, DataContructor);
            }
            else if (DataContructor.WhatToDo.SearchDubel == true)
            {
                WhichFun SelsectFunction = WhichFun.DoubleSearcer;
                Runner.RunMainThreadFunc(SelsectFunction, DataContructor);
            }
            else if (DataContructor.WhatToDo.CutPhotos == true)
            {
                WhichFun SelsectFunction = WhichFun.Scaler;
                Runner.RunMainThreadFunc(SelsectFunction, DataContructor);
            }
            else if (DataContructor.WhatToDo.ChangeNames == true)
            {
                WhichFun SelsectFunction = WhichFun.Rename;
                Runner.RunMainThreadFunc(SelsectFunction, DataContructor);
            }
            else
            {
                //Proces zakonczony
            }
        }
    }
}
