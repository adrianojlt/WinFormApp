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
using System.Configuration;

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

		private void btnConnection_Click(object sender, EventArgs e)
		{
			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WinFormApp.Properties.Settings.WinFormAppConnectionString"].ConnectionString;
			logOutput.AppendText(connectionString);
			connectionStrings();
		}

		private void connectionStrings()
		{
			System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			int count = ConfigurationManager.ConnectionStrings.Count;

			string newConn = "Data Source=SATELLITE;Initial Catalog=WinFormApp;Persist Security Info=True;User ID=adriano;Password=adriano";

			ConnectionStringSettings csSettings = new ConnectionStringSettings("newConn", newConn);

			ConnectionStringsSection csSession = config.ConnectionStrings;

			csSession.ConnectionStrings.Add(csSettings);

			config.Save(ConfigurationSaveMode.Modified);

			// force a reload
			ConfigurationManager.RefreshSection("appSettings");

			foreach (string key in ConfigurationManager.AppSettings)
			{
				logOutput.AppendText(key + " : " + ConfigurationManager.AppSettings[key]);
			}
		}

		private void btnTmp_Click(object sender, EventArgs e)
		{
			logOutput.Clear();
		}
    }
}
