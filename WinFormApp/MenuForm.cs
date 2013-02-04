using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class MenuForm : Form
    {
        public const string MENU_LEVEL0 = "TOP";
        public const string MENU_LEVEL1 = "CATEGORY";
        public const string MENU_LEVEL2 = "MENU";

        enum SaveModeEnum
        {
            add,
            edit
        }

        private SaveModeEnum save_mode;

        private List<Menus> menusDB;

        TreeNode selectedNode;

        public MenuForm()
        {
            InitializeComponent();
        }

        private void menuForm_load(object sender, EventArgs e)
        {
        }

        private void loadTreeMenu()
        {
            this.menuTree.Nodes.Clear();

            // retrieve all menus from DB
            DataClasses1DataContext ctx = new DataClasses1DataContext();
            this.menusDB = (from m in ctx.Menus select m).ToList();

            // root menus only ...
            Menus[] rootMenus = menusDB.FindAll(i => i.idParentMenu == null).ToArray();
            
            // sort them ...
            Array.Sort(rootMenus, delegate(Menus mn1, Menus mn2)
            { return (int)(mn1.MenuOrder - mn2.MenuOrder); });

            // add ROOT
            foreach (var item in rootMenus)
            {
                TreeNode rootNode = new TreeNode();
                rootNode.Name = item.idMenu.ToString();
                rootNode.Text = item.MenuName;
                rootNode.Tag = item;
                menuTree.Nodes.Add(rootNode);

                Menus[] subMenu = menusDB.FindAll(i => i.idParentMenu == item.idMenu).ToArray();

                // check if there is a subMenu for this rootMenu ...
                if (subMenu != null && subMenu.Length != 0)
                {
                    Array.Sort(subMenu, delegate(Menus mn1, Menus mn2)
                    { return (int)(mn1.MenuOrder - mn2.MenuOrder); });

                    // add SUB
                    fillNodes(subMenu,rootNode);
                }
            } 
            
            try
            {
                menuTree.SelectedNode = menuTree.Nodes.Find(selectedNode.Name, true).First();
                menuTree.Select();
            }
            catch (NullReferenceException)
            { 
            }
        }

        private void fillNodes(Menus[] menus, TreeNode superNode)
        {
            foreach (var item in menus)
            {
                TreeNode node = new TreeNode();
                node.Name = item.idMenu.ToString();
                node.Text = item.MenuName;
                node.Tag = item;
                superNode.Nodes.Add(node);

                Menus[] subMenu = menusDB.FindAll(i => i.idParentMenu == item.idMenu).ToArray();

                if (subMenu != null && subMenu.Length != 0)
                {
                    Array.Sort(subMenu, delegate(Menus mn1, Menus mn2)
                    { return (int)(mn1.MenuOrder - mn2.MenuOrder); });

                    // ... inception :)
                    fillNodes(subMenu,node);
                }
            }
        }

        private void enableInputs(bool enable)
        {
            if (enable == true)
            {
                inputName.Enabled = true;
                inputDescription.Enabled = true;
            }
            else
            {
                inputName.Enabled = false;
                inputDescription.Enabled = false;
            }
        }

        private void clearInputs()
        {
            inputName.Text = "";
            inputDescription.Text = "";
        }

        private void btnLoadTree_Click(object sender, EventArgs e)
        {
            loadTreeMenu();
        }

        private void menuTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedNode = menuTree.SelectedNode;
            Menus selectedMenu = this.menusDB.Find(i => i.idMenu == Convert.ToInt32(e.Node.Name));

            inputName.Text = selectedMenu.MenuName;
            inputDescription.Text = selectedMenu.Description;

            enableInputs(false);

            if (MENU_LEVEL2.Equals(selectedMenu.MenuType)) btnAdd.Enabled = false; else btnAdd.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            save_mode = SaveModeEnum.edit;

            //TreeNode selectedNode = menuTree.SelectedNode;
            selectedNode = menuTree.SelectedNode;
            menuTree.SelectedNode = selectedNode;
            menuTree.Select();

            try
            {
                Menus selectedMenu = this.menusDB.Find(i => i.idMenu == Convert.ToInt32(menuTree.SelectedNode.Name));
                enableInputs(true);
                inputName.Text = selectedMenu.MenuName;
                inputDescription.Text = selectedMenu.Description;
                menuTree.SelectedNode = selectedNode;
                menuTree.Select();
            }
            catch (NullReferenceException)
            { 

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            save_mode = SaveModeEnum.add;
            selectedNode = menuTree.SelectedNode;
            menuTree.SelectedNode = selectedNode;
            menuTree.Select();

            this.clearInputs();
            this.enableInputs(true);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            selectedNode = menuTree.SelectedNode;
            menuTree.SelectedNode = selectedNode;
            menuTree.Select();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (inputName.Enabled == false)
                return;

            DataClasses1DataContext ctx = new DataClasses1DataContext();

            switch (save_mode)
            {
                case SaveModeEnum.edit:
                    MessageBox.Show("edit");
                    break;
                case SaveModeEnum.add:
                    MessageBox.Show("add");
                    break;
                default:
                    break;
            }

            // Save data here ...
            //Menus data = (from m in ctx.Menus where m.idMenu

            // load data from db ...

            // select the new added menus

            // ... tmp
            selectedNode = menuTree.SelectedNode;
            menuTree.SelectedNode = selectedNode;
            menuTree.Select();

            this.enableInputs(false);
        }

      
    }
}
