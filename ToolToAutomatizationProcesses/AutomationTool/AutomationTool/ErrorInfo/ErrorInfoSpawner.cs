// Copyright Mateusz Bernacki. All Rights Reserved.
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTool.ErrorInfo
{
    /// <summary>
    /// Klasa spawnuje okno o błędzie
    /// </summary>
    class ErrorInfoSpawner
    {
        /// <summary>
        /// Funkcja służy do wyświetlania błędów 
        /// </summary>
        /// <param name="Name">Nazwa błędu</param>
        /// <param name="Value">Opis błędu</param>
        public static void PrintError(string Name, string Value)
        {
            AutoToolErrorInfo Info = new AutoToolErrorInfo(Value, Name);
            Info.ShowDialog();
        }
    }
}
