namespace WinFormApp
{
    partial class MainForm
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
            this.tree = new System.Windows.Forms.TreeView();
            this.btnTmp = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.Location = new System.Drawing.Point(12, 12);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(159, 345);
            this.tree.TabIndex = 0;
            // 
            // btnTmp
            // 
            this.btnTmp.Location = new System.Drawing.Point(178, 333);
            this.btnTmp.Name = "btnTmp";
            this.btnTmp.Size = new System.Drawing.Size(75, 23);
            this.btnTmp.TabIndex = 1;
            this.btnTmp.Text = "btnTmp";
            this.btnTmp.UseVisualStyleBackColor = true;
            this.btnTmp.Click += new System.EventHandler(this.btnTmp_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(178, 12);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(75, 23);
            this.btnMenu.TabIndex = 2;
            this.btnMenu.Text = "btnMenu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 372);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnTmp);
            this.Controls.Add(this.tree);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinFormApp";
            this.Load += new System.EventHandler(this.WinFormApp_load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.Button btnTmp;
        private System.Windows.Forms.Button btnMenu;
    }
}

