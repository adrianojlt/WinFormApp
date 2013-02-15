using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormApp;

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
			mainForm();
        }

		static void mainForm()
		{
			MainForm mainForm = new MainForm();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(mainForm);
		}

		static void menuForm()
		{
            MenuForm menuForm = new MenuForm();
            menuForm.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(menuForm);
		}

		static void tmp()
		{
			//Person p = new Person();
			//p.doSomething();
		}
    }


	public partial class TmpForm : Form 
	{
	    public TmpForm() { }

	    public void asdf() { }
	}
}
