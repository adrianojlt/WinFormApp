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
	public partial class ChooseMenu : Form
	{

		public const string BUTTON_SELECT_LABEL = "Select";
		public const string BUTTON_CANCEL_LABEL = "Cancel";
		public const string BUTTON_SAVE_LABEL = "Save";
		public const string BUTTON_BACK_LABEL = "Back";

		private FlowLayoutPanel painel;

		private Label lbl1, lbl2, lbl3;

		private TextBox tb1, tb2;

		private RichTextBox tb3;

		private int inputBoxWidth = 200;

		private MenuManager menuManager;

        private List<Menus> menusDB;

		private enum Buttons
		{
			select,
			cancel,
			save,
			back
		}

		private Button activeButton;

		public ChooseMenu()
		{
			InitializeComponent();
			InitMyUI();
			Init();
		}

		private void Init()
		{
			this.menuManager = new MenuManager();
		}

		private void InitMyUI()
		{
			this.painel = new FlowLayoutPanel();
			painel.Location = treeMenus.Location;
			painel.Size = treeMenus.Size;
			painel.SuspendLayout();
			//painel.BackColor = Color.Blue;

			this.lbl1 = new System.Windows.Forms.Label();
			this.lbl2 = new System.Windows.Forms.Label();
			this.lbl3 = new System.Windows.Forms.Label();

			this.tb1 = new TextBox();
			this.tb2 = new TextBox();
			this.tb3 = new RichTextBox();

			this.lbl1.AutoSize = true;
			this.lbl1.Location = new System.Drawing.Point(12, 14);
			this.lbl1.Name = "lbl1";
			this.lbl1.Size = new System.Drawing.Size(35, 13);
			this.lbl1.TabIndex = 0;
			this.lbl1.Text = "label1";

			this.lbl2.AutoSize = true;
			this.lbl2.Location = new System.Drawing.Point(12, 40);
			this.lbl2.Name = "lbl2";
			this.lbl2.Size = new System.Drawing.Size(35, 13);
			this.lbl2.TabIndex = 2;
			this.lbl2.Text = "label1";

			this.lbl3.AutoSize = true;
			this.lbl3.Location = new System.Drawing.Point(12, 66);
			this.lbl3.Name = "lbl3";
			this.lbl3.Size = new System.Drawing.Size(35, 13);
			this.lbl3.TabIndex = 5;
			this.lbl3.Text = "label1";

			this.tb1.Location = new System.Drawing.Point(53, 11);
			this.tb1.Name = "tb1";
			this.tb1.Size = new System.Drawing.Size(inputBoxWidth, 20);
			this.tb1.TabIndex = 1;

			this.tb2.Location = new System.Drawing.Point(53, 37);
			this.tb2.Name = "tb2";
			this.tb2.Size = new System.Drawing.Size(inputBoxWidth, 20);
			this.tb2.TabIndex = 3;

			this.tb3.Location = new System.Drawing.Point(53, 63);
			this.tb3.Name = "tb3";
			this.tb3.Size = new System.Drawing.Size(inputBoxWidth, 44);
			this.tb3.TabIndex = 4;
			this.tb3.Text = "";
			
			/*
			this.lbl1.AutoSize = true;
			this.lbl1.Location = new System.Drawing.Point(18, 27);
			this.lbl1.Name = "lbl1";
			this.lbl1.Size = new System.Drawing.Size(35, 13);
			this.lbl1.TabIndex = 0;
			this.lbl1.Text = "label1";
			*/


			painel.Controls.Add(lbl1);
			painel.Controls.Add(lbl2);
			painel.Controls.Add(lbl3);
			painel.Controls.Add(tb1);
			painel.Controls.Add(tb2);
			painel.Controls.Add(tb3);

			//painel.Controls.Add(tb1);
			//painel.Controls.Add(lb2);
			//painel.Controls.Add(tb2);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (btnOK.Text.Equals(BUTTON_SAVE_LABEL))
			{
				this.Controls.Remove(painel);
				this.Controls.Add(treeMenus);
				this.btnOK.Text = BUTTON_SELECT_LABEL;
				this.btnCancel.Text = BUTTON_CANCEL_LABEL;
			}
			else
			{
				this.Controls.Remove(treeMenus);
				this.Controls.Add(painel);
				this.btnOK.Text = BUTTON_SAVE_LABEL;
				this.btnCancel.Text = BUTTON_BACK_LABEL;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (btnCancel.Text.Equals(BUTTON_CANCEL_LABEL))
			{
				this.Close();
			}
			else
			{
				this.Controls.Remove(painel);
				this.Controls.Add(treeMenus);
				this.btnOK.Text = BUTTON_SELECT_LABEL;
				this.btnCancel.Text = BUTTON_CANCEL_LABEL;
			}
		}

		private void ChooseMenu_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		private void treeMenus_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		private void ChooseMenu_Load(object sender, EventArgs e)
		{
			this.menuManager.loadTreeMenu(ref this.treeMenus, ref this.menusDB);
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			foreach (TreeNode node in this.treeMenus.Nodes)
			{
				if (node.Text.ToUpper().Contains(this.txtSearch.Text.ToUpper()) && txtSearch.Text != "")
					node.ForeColor = Color.Blue;
				else
					node.ForeColor = Color.Black;
			}
		}
	}
}
