using AutomationTool.Settings;

namespace AutomationTool.Helpers
{
    public enum SelectedLang
    {
        Polish, 
        Engilsh
    }
    public class FormDataConstructor
    {
        public TaskForm InfoForm;
        public WhatDo WhatToDo;
        public string FolderPath;
        public Form1 StartForm;
        public string PreForm;
        public SelectedLang SelectedLaunguage;
    }
}
