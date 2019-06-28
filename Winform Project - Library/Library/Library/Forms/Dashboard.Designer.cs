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
            this.LblUser = new System.Windows.Forms.Label();
            this.LblUserName = new System.Windows.Forms.Label();
            this.btnexit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicLibrarian)).BeginInit();
            this.metroContextMenu2.SuspendLayout();
            this.metroContextMenu3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PicLibrarian
            // 
            this.PicLibrarian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PicLibrarian.Image = ((System.Drawing.Image)(resources.GetObject("PicLibrarian.Image")));
            this.PicLibrarian.Location = new System.Drawing.Point(685, 270);
            this.PicLibrarian.Name = "PicLibrarian";
            this.PicLibrarian.Size = new System.Drawing.Size(619, 723);
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
            // LblUser
            // 
            this.LblUser.AutoSize = true;
            this.LblUser.Location = new System.Drawing.Point(13, 22);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(47, 20);
            this.LblUser.TabIndex = 3;
            this.LblUser.Text = "User:";
            // 
            // LblUserName
            // 
            this.LblUserName.AutoSize = true;
            this.LblUserName.Location = new System.Drawing.Point(67, 22);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(0, 20);
            this.LblUserName.TabIndex = 4;
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(126, 324);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(336, 211);
            this.btnexit.TabIndex = 5;
            this.btnexit.Text = "exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.Btnexit_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1506, 1050);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.LblUserName);
            this.Controls.Add(this.LblUser);
            this.Controls.Add(this.PicLibrarian);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.Text = "Library";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.PicLibrarian)).EndInit();
            this.metroContextMenu2.ResumeLayout(false);
            this.metroContextMenu3.ResumeLayout(false);
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
        private System.Windows.Forms.Label LblUser;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.Button btnexit;
    }
}