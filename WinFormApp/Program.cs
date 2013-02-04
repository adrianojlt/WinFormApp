﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());

            Form menuForm = new MenuForm();
            menuForm.StartPosition = FormStartPosition.CenterScreen;
            menuForm.Show();
            Application.Run(menuForm);

            //Application.Run(new TmpForm());
        }
    }

    //class TmpForm : Form { }
}
