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
            populateTree();
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

        public void populateTree()
        {

            // first node
            TreeNode first = new TreeNode();
            first.Name = "1";
            first.Text = "root01";

            TreeNode ch0101 = new TreeNode();
            ch0101.Name = "2";
            ch0101.Text = "ch0101";
            TreeNode ch0102 = new TreeNode();
            ch0102.Name = "3";
            ch0102.Text = "ch0102";

            ch0102.Nodes.Add(new TreeNode("."));
            ch0102.Nodes.Add(new TreeNode(".."));
            
            first.Nodes.Add(ch0101);
            first.Nodes.Add(ch0102);

            // secound node
            TreeNode secound = new TreeNode();
            secound.Name = "2";
            secound.Text = "root02";

            

            tree.Nodes.Add(first);
            tree.Nodes.Add(secound);
        }

        private void btnTmp_Click(object sender, EventArgs e)
        {
            List<MenuType> tmp = getMenuType();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Form menuForm = new MenuForm();
            menuForm.StartPosition = FormStartPosition.CenterScreen;
            menuForm.Show();
        }

        private void WinFormApp_load(object sender, EventArgs e)
        {

        }
    }
}
