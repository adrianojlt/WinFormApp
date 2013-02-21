using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp
{

	class MenuManager
	{
        public const string MENU_LEVEL0 = "TOP";
        public const string MENU_LEVEL1 = "CATEGORY";
        public const string MENU_LEVEL2 = "MENU";

		// check how to assign vars by reference ...
		//private List<Menus> menus;
		//public TreeNode selectedNode;

		public void loadTreeMenu(ref TreeView menuTree, ref List<Menus>menusDB)
		{
            menuTree.Nodes.Clear();

            // retrieve all menus from DB
            DataClasses1DataContext ctx = new DataClasses1DataContext();
            menusDB = (from m in ctx.Menus select m).ToList();

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
                    fillNodes(subMenu,rootNode, ref menusDB);
                }
            } 
		}

		private void fillNodes(Menus[] menus, TreeNode superNode, ref List<Menus>menusDB)
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
                    fillNodes(subMenu,node, ref menusDB);
                }
            }
		}
	}
}
