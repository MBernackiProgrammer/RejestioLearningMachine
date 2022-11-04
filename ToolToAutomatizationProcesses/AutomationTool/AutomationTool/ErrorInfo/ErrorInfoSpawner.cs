using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTool.ErrorInfo
{
    class ErrorInfoSpawner
    {
        public static void PrintError(string Name, string Value)
        {
            AutoToolErrorInfo Info = new AutoToolErrorInfo(Value, Name);
            Info.ShowDialog();
            
        }
    }
}
