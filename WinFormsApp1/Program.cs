using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

          
                
            Application.Run(new Form1());
            
        }
    }
}