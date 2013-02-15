namespace WinFormApp
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.menuTree = new System.Windows.Forms.TreeView();
			this.btnLoadTree = new System.Windows.Forms.Button();
			this.inputName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.inputDescription = new System.Windows.Forms.RichTextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.menuRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuTree
			// 
			this.menuTree.Location = new System.Drawing.Point(13, 13);
			this.menuTree.Name = "menuTree";
			this.menuTree.Size = new System.Drawing.Size(192, 323);
			this.menuTree.TabIndex = 0;
			this.menuTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.menuTree_AfterSelect);
			this.menuTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.menuTree_KeyDown);
			this.menuTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.menuTree_MouseUp);
			// 
			// btnLoadTree
			// 
			this.btnLoadTree.Location = new System.Drawing.Point(211, 313);
			this.btnLoadTree.Name = "btnLoadTree";
			this.btnLoadTree.Size = new System.Drawing.Size(75, 23);
			this.btnLoadTree.TabIndex = 1;
			this.btnLoadTree.Text = "Load";
			this.btnLoadTree.UseVisualStyleBackColor = true;
			this.btnLoadTree.Click += new System.EventHandler(this.btnLoadTree_Click);
			// 
			// inputName
			// 
			this.inputName.Location = new System.Drawing.Point(398, 13);
			this.inputName.Name = "inputName";
			this.inputName.Size = new System.Drawing.Size(138, 20);
			this.inputName.TabIndex = 2;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(357, 16);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(38, 13);
			this.lblName.TabIndex = 3;
			this.lblName.Text = "Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(332, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Description:";
			// 
			// inputDescription
			// 
			this.inputDescription.Location = new System.Drawing.Point(398, 49);
			this.inputDescription.Name = "inputDescription";
			this.inputDescription.Size = new System.Drawing.Size(138, 61);
			this.inputDescription.TabIndex = 5;
			this.inputDescription.Text = "";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(461, 313);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 9;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// ctxMenu
			// 
			this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEdit,
            this.menuAdd,
            this.menuRemove});
			this.ctxMenu.Name = "ctxMenu";
			this.ctxMenu.Size = new System.Drawing.Size(114, 70);
			// 
			// menuEdit
			// 
			this.menuEdit.Name = "menuEdit";
			this.menuEdit.Size = new System.Drawing.Size(113, 22);
			this.menuEdit.Text = "Edit";
			this.menuEdit.Click += new System.EventHandler(this.menuEdit_Click);
			// 
			// menuAdd
			// 
			this.menuAdd.Name = "menuAdd";
			this.menuAdd.Size = new System.Drawing.Size(113, 22);
			this.menuAdd.Text = "Add";
			this.menuAdd.Click += new System.EventHandler(this.menuAdd_Click);
			// 
			// menuRemove
			// 
			this.menuRemove.Name = "menuRemove";
			this.menuRemove.Size = new System.Drawing.Size(113, 22);
			this.menuRemove.Text = "Remove";
			this.menuRemove.Click += new System.EventHandler(this.menuRemove_Click);
			// 
			// MenuForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(548, 348);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.inputDescription);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.inputName);
			this.Controls.Add(this.btnLoadTree);
			this.Controls.Add(this.menuTree);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MenuForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MenuForm";
			this.Load += new System.EventHandler(this.menuForm_load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MenuForm_KeyDown);
			this.ctxMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView menuTree;
        private System.Windows.Forms.Button btnLoadTree;
        private System.Windows.Forms.TextBox inputName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox inputDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuAdd;
        private System.Windows.Forms.ToolStripMenuItem menuRemove;
    }
}