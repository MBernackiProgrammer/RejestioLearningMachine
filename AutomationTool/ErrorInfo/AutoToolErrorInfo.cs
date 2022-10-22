using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutomationTool.ErrorInfo
{
    public partial class AutoToolErrorInfo : Form
    {
        public AutoToolErrorInfo(string ErrorValue, string ErrorTitle)
        {
            InitializeComponent();

            L_Nazwa.Text = ErrorTitle;
            L_Value.Text = ErrorValue;
            this.Text = ErrorTitle;
        }
    }
}
