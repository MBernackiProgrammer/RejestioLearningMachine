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
            RunInfo.StartForm.Invoke((MethodInvoker)(() => RunInfo.StartForm.RunFunction(Which, RunInfo)));
        }
    }
}
