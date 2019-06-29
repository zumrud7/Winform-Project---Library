namespace Library.Forms
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.PicLibrarian = new System.Windows.Forms.PictureBox();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.metroContextMenu2 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroContextMenu3 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.metorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LblUserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnAccount = new System.Windows.Forms.Button();
            this.BtnBook = new System.Windows.Forms.Button();
            this.BtnCustomer = new System.Windows.Forms.Button();
            this.BtnUser = new System.Windows.Forms.Button();
            this.BtnHome = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnExit = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicLibrarian)).BeginInit();
            this.metroContextMenu2.SuspendLayout();
            this.metroContextMenu3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // PicLibrarian
            // 
            this.PicLibrarian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PicLibrarian.Image = ((System.Drawing.Image)(resources.GetObject("PicLibrarian.Image")));
            this.PicLibrarian.Location = new System.Drawing.Point(1330, 390);
            this.PicLibrarian.Name = "PicLibrarian";
            this.PicLibrarian.Size = new System.Drawing.Size(531, 603);
            this.PicLibrarian.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLibrarian.TabIndex = 0;
            this.PicLibrarian.TabStop = false;
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(61, 4);
            // 
            // metroContextMenu2
            // 
            this.metroContextMenu2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.metroContextMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem});
            this.metroContextMenu2.Name = "metroContextMenu2";
            this.metroContextMenu2.Size = new System.Drawing.Size(134, 36);
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(133, 32);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // metroContextMenu3
            // 
            this.metroContextMenu3.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.metroContextMenu3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.metorToolStripMenuItem});
            this.metroContextMenu3.Name = "metroContextMenu3";
            this.metroContextMenu3.Size = new System.Drawing.Size(140, 36);
            // 
            // metorToolStripMenuItem
            // 
            this.metorToolStripMenuItem.Name = "metorToolStripMenuItem";
            this.metorToolStripMenuItem.Size = new System.Drawing.Size(139, 32);
            this.metorToolStripMenuItem.Text = "metor\\";
            // 
            // LblUserName
            // 
            this.LblUserName.AutoSize = true;
            this.LblUserName.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUserName.Location = new System.Drawing.Point(101, 110);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(0, 39);
            this.LblUserName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(846, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 65);
            this.label1.TabIndex = 8;
            this.label1.Text = "LIBRARY";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnAccount);
            this.panel1.Controls.Add(this.BtnBook);
            this.panel1.Controls.Add(this.BtnCustomer);
            this.panel1.Controls.Add(this.BtnUser);
            this.panel1.Controls.Add(this.BtnHome);
            this.panel1.Location = new System.Drawing.Point(10, 199);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1884, 147);
            this.panel1.TabIndex = 9;
            // 
            // BtnAccount
            // 
            this.BtnAccount.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BtnAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAccount.FlatAppearance.BorderSize = 0;
            this.BtnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAccount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnAccount.Location = new System.Drawing.Point(1514, 3);
            this.BtnAccount.Name = "BtnAccount";
            this.BtnAccount.Size = new System.Drawing.Size(370, 128);
            this.BtnAccount.TabIndex = 16;
            this.BtnAccount.TabStop = false;
            this.BtnAccount.Text = "ACCOUNT";
            this.BtnAccount.UseVisualStyleBackColor = false;
            this.BtnAccount.Click += new System.EventHandler(this.BtnAccount_Click);
            // 
            // BtnBook
            // 
            this.BtnBook.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BtnBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBook.FlatAppearance.BorderSize = 0;
            this.BtnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBook.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnBook.Location = new System.Drawing.Point(1138, 3);
            this.BtnBook.Name = "BtnBook";
            this.BtnBook.Size = new System.Drawing.Size(370, 128);
            this.BtnBook.TabIndex = 15;
            this.BtnBook.TabStop = false;
            this.BtnBook.Text = "BOOKS";
            this.BtnBook.UseVisualStyleBackColor = false;
            this.BtnBook.Click += new System.EventHandler(this.BtnBook_Click);
            // 
            // BtnCustomer
            // 
            this.BtnCustomer.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BtnCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCustomer.FlatAppearance.BorderSize = 0;
            this.BtnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCustomer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnCustomer.Location = new System.Drawing.Point(762, 3);
            this.BtnCustomer.Name = "BtnCustomer";
            this.BtnCustomer.Size = new System.Drawing.Size(370, 128);
            this.BtnCustomer.TabIndex = 14;
            this.BtnCustomer.TabStop = false;
            this.BtnCustomer.Text = "CUSTOMERS";
            this.BtnCustomer.UseVisualStyleBackColor = false;
            this.BtnCustomer.Click += new System.EventHandler(this.BtnCustomer_Click);
            // 
            // BtnUser
            // 
            this.BtnUser.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BtnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUser.FlatAppearance.BorderSize = 0;
            this.BtnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnUser.Location = new System.Drawing.Point(386, 3);
            this.BtnUser.Name = "BtnUser";
            this.BtnUser.Size = new System.Drawing.Size(370, 128);
            this.BtnUser.TabIndex = 13;
            this.BtnUser.TabStop = false;
            this.BtnUser.Text = "USERS";
            this.BtnUser.UseVisualStyleBackColor = false;
            this.BtnUser.Click += new System.EventHandler(this.BtnUser_Click);
            // 
            // BtnHome
            // 
            this.BtnHome.BackColor = System.Drawing.Color.MediumTurquoise;
            this.BtnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnHome.FlatAppearance.BorderSize = 0;
            this.BtnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnHome.Location = new System.Drawing.Point(10, 3);
            this.BtnHome.Name = "BtnHome";
            this.BtnHome.Size = new System.Drawing.Size(370, 128);
            this.BtnHome.TabIndex = 12;
            this.BtnHome.TabStop = false;
            this.BtnHome.Text = "HOME";
            this.BtnHome.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Cornsilk;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(1597, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 51);
            this.button2.TabIndex = 11;
            this.button2.TabStop = false;
            this.button2.Text = "LOG OUT";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(39, 98);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.Cornsilk;
            this.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnExit.FlatAppearance.BorderSize = 2;
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnExit.Location = new System.Drawing.Point(1751, 98);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(127, 51);
            this.BtnExit.TabIndex = 13;
            this.BtnExit.TabStop = false;
            this.BtnExit.Text = "EXIT";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(39, 127);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1906, 1050);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblUserName);
            this.Controls.Add(this.PicLibrarian);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.Text = "Library";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PicLibrarian)).EndInit();
            this.metroContextMenu2.ResumeLayout(false);
            this.metroContextMenu3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicLibrarian;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu2;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu3;
        private System.Windows.Forms.ToolStripMenuItem metorToolStripMenuItem;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnAccount;
        private System.Windows.Forms.Button BtnBook;
        private System.Windows.Forms.Button BtnCustomer;
        private System.Windows.Forms.Button BtnUser;
        private System.Windows.Forms.Button BtnHome;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}