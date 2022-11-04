// Copyright Mateusz Bernacki. All Rights Reserved.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutomationTool.ErrorInfo
{
    /// <summary>
    /// Klasa odpowiada za pokazanie informacji o błędzie
    /// </summary>
    public partial class AutoToolErrorInfo : Form
    {
        /// <summary>
        /// Konstuktor klasy AutoToolErrorInfo, który jest formem i odpowiada za wyświetlenie wiadomości o błędzie
        /// </summary>
        /// <param name="ErrorValue">Nazwa błędu</param>
        /// <param name="ErrorTitle">Opis błędu</param>
        public AutoToolErrorInfo(string ErrorValue, string ErrorTitle)
        {
            //Inicjalizacja formu 
            InitializeComponent();

            //Przekazanie wartości
            L_Nazwa.Text = ErrorTitle;
            L_Value.Text = ErrorValue;
            this.Text = ErrorTitle;
        }
    }
}
