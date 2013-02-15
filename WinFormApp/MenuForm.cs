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

        enum SaveMode
        {
            add,
            edit
        }

        private SaveMode activeMode;

        private List<Menus> menusDB;

		public TreeNode selectedNode;

        public MenuForm()
        {
            InitializeComponent();
        }

        private void menuForm_load(object sender, EventArgs e)
        {
            loadTreeMenu();
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
            catch (Exception)
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
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            activeMode = SaveMode.edit;

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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            selectedNode = menuTree.SelectedNode;
            menuTree.SelectedNode = selectedNode;
            menuTree.Select();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (inputName.Enabled == false) return;

            this.selectedNode = menuTree.SelectedNode;

            DataClasses1DataContext ctx = new DataClasses1DataContext();
            
            switch (activeMode)
            {
                case SaveMode.edit:

                    int nodeId = Convert.ToInt32(this.selectedNode.Name);

                    try
                    { 
                        Menus menu2edit = (from m in ctx.Menus where m.idMenu == nodeId select m).First();
                        menu2edit.MenuName = inputName.Text;
                        menu2edit.Description = inputDescription.Text;
                    }
                    catch (Exception) { }

                    break;
                case SaveMode.add:

                    Menus menu2add = new Menus();

                    try
                    {
                        if (menuTree.SelectedNode == null)
                        {// add root menu ...

                            menu2add.idParentMenu = null;

                            menu2add.MenuType = MENU_LEVEL0;

                            int? lastMenu = menusDB.FindAll(i => i.idParentMenu == null).Max(i => i.MenuOrder);

                            if (lastMenu == null) 
                                menu2add.MenuOrder = 1; 
                            else 
                                menu2add.MenuOrder = lastMenu + 1;
                        }
                        else
                        {
                            Menus selectedNode = menusDB.Find(i => i.idMenu == Convert.ToInt32(menuTree.SelectedNode.Name));

                            if (selectedNode.idParentMenu == null)
                            {
                                menu2add.idParentMenu = selectedNode.idMenu;
                                menu2add.MenuType = MENU_LEVEL1;
                            }
                            else
                            {
                                menu2add.idParentMenu = selectedNode.idMenu;
                                menu2add.MenuType = MENU_LEVEL2;
                            }
                        }

			menu2add.MenuName = inputName.Text;
			menu2add.Description = inputDescription.Text;
			ctx.Menus.InsertOnSubmit(menu2add);
                    }
                    catch (Exception) { }
                    break;
                default:
                    break;
            }

            ctx.SubmitChanges();

            loadTreeMenu();

            this.enableInputs(false);
        }

        private void menuEdit_Click(object sender, EventArgs e)
        {
            activeMode = SaveMode.edit;

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

        private void menuTree_MouseUp(object sender, MouseEventArgs e)
        {
            // mouse right click ...
            if (e.Button == MouseButtons.Right)
            {
                Point point = new Point(e.X,e.Y);
                menuTree.PointToClient(point); 
                this.selectedNode = menuTree.GetNodeAt(point);

                if (selectedNode != null)
                { // hover a node
                    if (selectedNode.Bounds.Contains(point))
                    { 

                        Menus selectedMenu = menusDB.Find(i => i.idMenu == Convert.ToInt32(selectedNode.Name));

                        // remove ADD option from last order menu
                        if (selectedMenu.MenuType.Equals(MENU_LEVEL2))
                        { menuAdd.Enabled = false; }
                        else
                        { menuAdd.Enabled = true; }

                        menuTree.SelectedNode = this.selectedNode;

                        //  EDIT/REMOVE is always possible when a node is selected ...
                        menuEdit.Enabled = true;
                        menuRemove.Enabled = true;
                        ctxMenu.Show(menuTree, point);
                    }
                }
                else
                { // hover an empty space
                    menuEdit.Enabled = false;
                    menuAdd.Enabled = true;
                    menuRemove.Enabled = false;

                    selectedNode = null;
                    menuTree.SelectedNode = null;
                    ctxMenu.Show(menuTree, point);
                }
            }
        }

        private void menuAdd_Click(object sender, EventArgs e)
        {
            activeMode = SaveMode.add;

            try
            {
                menuTree.SelectedNode.Expand();
                menuTree.Select();
            }
            catch (NullReferenceException) { }

            this.clearInputs();
            this.enableInputs(true);
        }

        private void menuRemove_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Delete???","attention",MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialog)
            {
                DataClasses1DataContext ctx = new DataClasses1DataContext();
                int? id = Convert.ToInt32(menuTree.SelectedNode.Name);
                Menus menu2delete = (from m in ctx.Menus where m.idMenu == id select m).First();
                ctx.Menus.DeleteOnSubmit(menu2delete);
                ctx.SubmitChanges();
                loadTreeMenu();
            }
        }

	public void something()
	{
		MessageBox.Show("hello");
	}

	public static void qwerty() 
	{
			
	}

	private void MenuForm_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			Close();
		}
	}

	private void menuTree_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			Close();
		}
	}
      
    }
}
