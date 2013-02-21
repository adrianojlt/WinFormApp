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
			this.btnMenu = new System.Windows.Forms.Button();
			this.btnChoose = new System.Windows.Forms.Button();
			this.btnConnection = new System.Windows.Forms.Button();
			this.logOutput = new System.Windows.Forms.RichTextBox();
			this.lblDataSource = new System.Windows.Forms.Label();
			this.lblInitialCatalog = new System.Windows.Forms.Label();
			this.lblUser = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.inputDataSource = new System.Windows.Forms.TextBox();
			this.inputInitialCatalog = new System.Windows.Forms.TextBox();
			this.inputUser = new System.Windows.Forms.TextBox();
			this.inputPassword = new System.Windows.Forms.TextBox();
			this.btnTmp = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnMenu
			// 
			this.btnMenu.Location = new System.Drawing.Point(12, 12);
			this.btnMenu.Name = "btnMenu";
			this.btnMenu.Size = new System.Drawing.Size(91, 23);
			this.btnMenu.TabIndex = 0;
			this.btnMenu.Text = "Manage Menus";
			this.btnMenu.UseVisualStyleBackColor = true;
			this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
			// 
			// btnChoose
			// 
			this.btnChoose.Location = new System.Drawing.Point(109, 12);
			this.btnChoose.Name = "btnChoose";
			this.btnChoose.Size = new System.Drawing.Size(89, 23);
			this.btnChoose.TabIndex = 1;
			this.btnChoose.Text = "Choose Menu";
			this.btnChoose.UseVisualStyleBackColor = true;
			this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
			// 
			// btnConnection
			// 
			this.btnConnection.Location = new System.Drawing.Point(193, 270);
			this.btnConnection.Name = "btnConnection";
			this.btnConnection.Size = new System.Drawing.Size(90, 21);
			this.btnConnection.TabIndex = 4;
			this.btnConnection.Text = "button1";
			this.btnConnection.UseVisualStyleBackColor = true;
			this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
			// 
			// logOutput
			// 
			this.logOutput.Location = new System.Drawing.Point(339, 97);
			this.logOutput.Name = "logOutput";
			this.logOutput.Size = new System.Drawing.Size(214, 196);
			this.logOutput.TabIndex = 5;
			this.logOutput.Text = "";
			// 
			// lblDataSource
			// 
			this.lblDataSource.AutoSize = true;
			this.lblDataSource.Location = new System.Drawing.Point(11, 178);
			this.lblDataSource.Name = "lblDataSource";
			this.lblDataSource.Size = new System.Drawing.Size(70, 13);
			this.lblDataSource.TabIndex = 6;
			this.lblDataSource.Text = "Data Source:";
			// 
			// lblInitialCatalog
			// 
			this.lblInitialCatalog.AutoSize = true;
			this.lblInitialCatalog.Location = new System.Drawing.Point(10, 209);
			this.lblInitialCatalog.Name = "lblInitialCatalog";
			this.lblInitialCatalog.Size = new System.Drawing.Size(73, 13);
			this.lblInitialCatalog.TabIndex = 7;
			this.lblInitialCatalog.Text = "Initial Catalog:";
			// 
			// lblUser
			// 
			this.lblUser.AutoSize = true;
			this.lblUser.Location = new System.Drawing.Point(11, 242);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(32, 13);
			this.lblUser.TabIndex = 8;
			this.lblUser.Text = "User:";
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(11, 274);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(56, 13);
			this.lblPassword.TabIndex = 9;
			this.lblPassword.Text = "Password:";
			// 
			// inputDataSource
			// 
			this.inputDataSource.Location = new System.Drawing.Point(87, 175);
			this.inputDataSource.Name = "inputDataSource";
			this.inputDataSource.Size = new System.Drawing.Size(100, 20);
			this.inputDataSource.TabIndex = 10;
			// 
			// inputInitialCatalog
			// 
			this.inputInitialCatalog.Location = new System.Drawing.Point(87, 206);
			this.inputInitialCatalog.Name = "inputInitialCatalog";
			this.inputInitialCatalog.Size = new System.Drawing.Size(100, 20);
			this.inputInitialCatalog.TabIndex = 11;
			// 
			// inputUser
			// 
			this.inputUser.Location = new System.Drawing.Point(87, 239);
			this.inputUser.Name = "inputUser";
			this.inputUser.Size = new System.Drawing.Size(100, 20);
			this.inputUser.TabIndex = 12;
			// 
			// inputPassword
			// 
			this.inputPassword.Location = new System.Drawing.Point(87, 271);
			this.inputPassword.Name = "inputPassword";
			this.inputPassword.Size = new System.Drawing.Size(100, 20);
			this.inputPassword.TabIndex = 13;
			// 
			// btnTmp
			// 
			this.btnTmp.Location = new System.Drawing.Point(205, 13);
			this.btnTmp.Name = "btnTmp";
			this.btnTmp.Size = new System.Drawing.Size(75, 23);
			this.btnTmp.TabIndex = 14;
			this.btnTmp.Text = "btnTmp";
			this.btnTmp.UseVisualStyleBackColor = true;
			this.btnTmp.Click += new System.EventHandler(this.btnTmp_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(565, 305);
			this.Controls.Add(this.btnTmp);
			this.Controls.Add(this.inputPassword);
			this.Controls.Add(this.inputUser);
			this.Controls.Add(this.inputInitialCatalog);
			this.Controls.Add(this.inputDataSource);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.lblUser);
			this.Controls.Add(this.lblInitialCatalog);
			this.Controls.Add(this.lblDataSource);
			this.Controls.Add(this.logOutput);
			this.Controls.Add(this.btnConnection);
			this.Controls.Add(this.btnChoose);
			this.Controls.Add(this.btnMenu);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "WinFormApp";
			this.Load += new System.EventHandler(this.WinFormApp_load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Button btnMenu;
		private System.Windows.Forms.Button btnChoose;
		private System.Windows.Forms.Button btnConnection;
		private System.Windows.Forms.RichTextBox logOutput;
		private System.Windows.Forms.Label lblDataSource;
		private System.Windows.Forms.Label lblInitialCatalog;
		private System.Windows.Forms.Label lblUser;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox inputDataSource;
		private System.Windows.Forms.TextBox inputInitialCatalog;
		private System.Windows.Forms.TextBox inputUser;
		private System.Windows.Forms.TextBox inputPassword;
		private System.Windows.Forms.Button btnTmp;

	}
}

