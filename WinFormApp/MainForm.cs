using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            myInit();
            //populateTree();
        }

        public void myInit()
        {
            //this.Text = "Calculator";
            //this.Size = new Size(200, 225);
        }

        public void tmp()
        {
            //IDbConnection myCn = new SqlConnection();
            //string connType = myCn.GetType().Name;
            //Console.WriteLine(" *** " + connType + " *** ");
        }

        public static List<MenuType> getMenuType()
        {
            DataClasses1DataContext ctx = new DataClasses1DataContext();
            var result = from r in ctx.MenuTypes select r;
            return result.ToList();
        }

        private void WinFormApp_load(object sender, EventArgs e)
        {

        }

		private void btnMenu_Click(object sender, EventArgs e)
		{
			MenuForm menuForm = new MenuForm();
			menuForm.Show();
		}

		private void btnChoose_Click(object sender, EventArgs e)
		{
			ChooseMenu chooseMenu = new ChooseMenu();
			chooseMenu.Show();
		}
    }
}
