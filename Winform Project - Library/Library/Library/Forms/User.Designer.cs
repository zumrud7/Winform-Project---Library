namespace Library.Forms
{
    partial class User
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PicIcon = new System.Windows.Forms.PictureBox();
            this.LblTitle = new System.Windows.Forms.Label();
            this.LblFirstName = new System.Windows.Forms.Label();
            this.TxtFirstName = new System.Windows.Forms.TextBox();
            this.LblLastName = new System.Windows.Forms.Label();
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.LblUserName = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.LblPassword = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.DgvUser = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtFN = new System.Windows.Forms.TextBox();
            this.LblFN = new System.Windows.Forms.Label();
            this.TxtUN = new System.Windows.Forms.TextBox();
            this.LblUN = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // PicIcon
            // 
            this.PicIcon.Image = ((System.Drawing.Image)(resources.GetObject("PicIcon.Image")));
            this.PicIcon.Location = new System.Drawing.Point(62, 34);
            this.PicIcon.Name = "PicIcon";
            this.PicIcon.Size = new System.Drawing.Size(103, 105);
            this.PicIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicIcon.TabIndex = 0;
            this.PicIcon.TabStop = false;
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Font = new System.Drawing.Font("Microsoft Tai Le", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.Location = new System.Drawing.Point(182, 52);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(215, 76);
            this.LblTitle.TabIndex = 1;
            this.LblTitle.Text = "USERS";
            // 
            // LblFirstName
            // 
            this.LblFirstName.AutoSize = true;
            this.LblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFirstName.Location = new System.Drawing.Point(43, 224);
            this.LblFirstName.Name = "LblFirstName";
            this.LblFirstName.Size = new System.Drawing.Size(125, 25);
            this.LblFirstName.TabIndex = 3;
            this.LblFirstName.Text = "First Name*";
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFirstName.Location = new System.Drawing.Point(48, 252);
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(252, 30);
            this.TxtFirstName.TabIndex = 4;
            // 
            // LblLastName
            // 
            this.LblLastName.AutoSize = true;
            this.LblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLastName.Location = new System.Drawing.Point(43, 324);
            this.LblLastName.Name = "LblLastName";
            this.LblLastName.Size = new System.Drawing.Size(124, 25);
            this.LblLastName.TabIndex = 5;
            this.LblLastName.Text = "Last Name*";
            // 
            // TxtLastName
            // 
            this.TxtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLastName.Location = new System.Drawing.Point(48, 352);
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(252, 30);
            this.TxtLastName.TabIndex = 6;
            // 
            // TxtUserName
            // 
            this.TxtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUserName.Location = new System.Drawing.Point(48, 449);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(252, 30);
            this.TxtUserName.TabIndex = 8;
            // 
            // LblUserName
            // 
            this.LblUserName.AutoSize = true;
            this.LblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUserName.Location = new System.Drawing.Point(43, 421);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(128, 25);
            this.LblUserName.TabIndex = 7;
            this.LblUserName.Text = "User Name*";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.Location = new System.Drawing.Point(48, 544);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(252, 30);
            this.TxtPassword.TabIndex = 10;
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPassword.Location = new System.Drawing.Point(43, 516);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(115, 25);
            this.LblPassword.TabIndex = 9;
            this.LblPassword.Text = "Password*";
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.Coral;
            this.BtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnAdd.Location = new System.Drawing.Point(181, 605);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(118, 52);
            this.BtnAdd.TabIndex = 11;
            this.BtnAdd.TabStop = false;
            this.BtnAdd.Text = "ADD";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.Color.Coral;
            this.BtnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUpdate.FlatAppearance.BorderSize = 0;
            this.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdate.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnUpdate.Location = new System.Drawing.Point(48, 605);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(118, 52);
            this.BtnUpdate.TabIndex = 12;
            this.BtnUpdate.TabStop = false;
            this.BtnUpdate.Text = "UPDATE";
            this.BtnUpdate.UseVisualStyleBackColor = false;
            this.BtnUpdate.Visible = false;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.OrangeRed;
            this.BtnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDelete.FlatAppearance.BorderSize = 0;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnDelete.Location = new System.Drawing.Point(181, 605);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(118, 52);
            this.BtnDelete.TabIndex = 13;
            this.BtnDelete.TabStop = false;
            this.BtnDelete.Text = "DELETE";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Visible = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // DgvUser
            // 
            this.DgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvUser.BackgroundColor = System.Drawing.Color.White;
            this.DgvUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.DgvUser.ColumnHeadersHeight = 40;
            this.DgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.MenuBar;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvUser.DefaultCellStyle = dataGridViewCellStyle20;
            this.DgvUser.EnableHeadersVisualStyles = false;
            this.DgvUser.Location = new System.Drawing.Point(357, 252);
            this.DgvUser.Name = "DgvUser";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.DgvUser.RowHeadersWidth = 62;
            this.DgvUser.RowTemplate.Height = 28;
            this.DgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvUser.Size = new System.Drawing.Size(725, 426);
            this.DgvUser.TabIndex = 14;
            this.DgvUser.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvUser_CellFormatting);
            this.DgvUser.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvUser_RowHeaderMouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "First Name";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Last Name";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "User Name";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Password";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            // 
            // TxtFN
            // 
            this.TxtFN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFN.Location = new System.Drawing.Point(491, 187);
            this.TxtFN.Name = "TxtFN";
            this.TxtFN.Size = new System.Drawing.Size(128, 30);
            this.TxtFN.TabIndex = 17;
            // 
            // LblFN
            // 
            this.LblFN.AutoSize = true;
            this.LblFN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFN.Location = new System.Drawing.Point(352, 190);
            this.LblFN.Name = "LblFN";
            this.LblFN.Size = new System.Drawing.Size(123, 25);
            this.LblFN.TabIndex = 16;
            this.LblFN.Text = "First Name:";
            // 
            // TxtUN
            // 
            this.TxtUN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUN.Location = new System.Drawing.Point(788, 189);
            this.TxtUN.Name = "TxtUN";
            this.TxtUN.Size = new System.Drawing.Size(131, 30);
            this.TxtUN.TabIndex = 19;
            // 
            // LblUN
            // 
            this.LblUN.AutoSize = true;
            this.LblUN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUN.Location = new System.Drawing.Point(646, 190);
            this.LblUN.Name = "LblUN";
            this.LblUN.Size = new System.Drawing.Size(126, 25);
            this.LblUN.TabIndex = 18;
            this.LblUN.Text = "User Name:";
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.Color.Coral;
            this.BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSearch.FlatAppearance.BorderSize = 0;
            this.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearch.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnSearch.Location = new System.Drawing.Point(964, 180);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(118, 52);
            this.BtnSearch.TabIndex = 20;
            this.BtnSearch.TabStop = false;
            this.BtnSearch.Text = "SEARCH";
            this.BtnSearch.UseVisualStyleBackColor = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1180, 844);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.TxtUN);
            this.Controls.Add(this.LblUN);
            this.Controls.Add(this.TxtFN);
            this.Controls.Add(this.LblFN);
            this.Controls.Add(this.DgvUser);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.LblPassword);
            this.Controls.Add(this.TxtUserName);
            this.Controls.Add(this.LblUserName);
            this.Controls.Add(this.TxtLastName);
            this.Controls.Add(this.LblLastName);
            this.Controls.Add(this.TxtFirstName);
            this.Controls.Add(this.LblFirstName);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.PicIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "User";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.PicIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicIcon;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Label LblFirstName;
        private System.Windows.Forms.TextBox TxtFirstName;
        private System.Windows.Forms.Label LblLastName;
        private System.Windows.Forms.TextBox TxtLastName;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.DataGridView DgvUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.TextBox TxtFN;
        private System.Windows.Forms.Label LblFN;
        private System.Windows.Forms.TextBox TxtUN;
        private System.Windows.Forms.Label LblUN;
        private System.Windows.Forms.Button BtnSearch;
    }
}