using Library.DAL;
using Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Forms
{
    public partial class User : Form
    {

        private readonly LibraryContext _context;

        private Library.Models.User SelectedUser;
        public User()
        {
            InitializeComponent();
            
            _context = new LibraryContext();

            FillUserDetails();
        }

        #region Fill DGV with user List
        private void FillUserDetails()
        {
            DgvUser.Rows.Clear();

            foreach (var item in _context.Users.ToList())
            {
                DgvUser.Rows.Add(item.Id,
                    item.FirstName,
                    item.LastName,
                    item.UserName,
                    item.Password);
            }
        }

        #endregion


        #region Methods

        private bool FormValidation()
        {
            if (string.IsNullOrEmpty(TxtFirstName.Text))
            {
                LblFirstName.ForeColor = Color.Red;
                LblLastName.ForeColor = SystemColors.ControlText;
                LblUserName.ForeColor = SystemColors.ControlText;
                LblPassword.ForeColor = SystemColors.ControlText;
                return false;
            }
            if (string.IsNullOrEmpty(TxtLastName.Text))
            {
                LblFirstName.ForeColor = SystemColors.ControlText;
                LblLastName.ForeColor = Color.Red;
                LblUserName.ForeColor = SystemColors.ControlText;
                LblPassword.ForeColor = SystemColors.ControlText;
                return false;
            }
            if (string.IsNullOrEmpty(TxtUserName.Text))
            {
                LblFirstName.ForeColor = SystemColors.ControlText;
                LblLastName.ForeColor = SystemColors.ControlText;
                LblUserName.ForeColor = Color.Red;
                LblPassword.ForeColor = SystemColors.ControlText;
                return false;
            }
            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                LblFirstName.ForeColor = SystemColors.ControlText;
                LblLastName.ForeColor = SystemColors.ControlText;
                LblUserName.ForeColor = SystemColors.ControlText;
                LblPassword.ForeColor = Color.Red;
                return false;
            }
            return true;



        }

        private void ButtonReset()
        {
            BtnAdd.Visible = true;
            BtnDelete.Visible = false;
            BtnUpdate.Visible = false;
        }

        private void FormReset()
        {
            TxtFirstName.Text = string.Empty;
            TxtLastName.Text = string.Empty;
            TxtUserName.Text = string.Empty;
            TxtPassword.Text = string.Empty;

            LblFirstName.ForeColor = SystemColors.ControlText;
            LblLastName.ForeColor = SystemColors.ControlText;
            LblUserName.ForeColor = SystemColors.ControlText;
            LblPassword.ForeColor = SystemColors.ControlText;

        }

        #endregion


        #region Button Functions

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!FormValidation())
            {
                return;

            };

            Library.Models.User user = new Library.Models.User();

            user.FirstName = TxtFirstName.Text;
            user.LastName = TxtLastName.Text;
            user.UserName = TxtUserName.Text;
            user.Password = TxtPassword.Text;


            #region Verifying that duplicate user name is not entered in the system
            List<Library.Models.User> us = _context.Users.Where(u => u.UserName.Contains(user.UserName)).ToList();

            foreach(var item in us)
            {
                if(item.UserName == user.UserName)
                {
                    LblUserName.ForeColor = Color.Red;
                    MessageBox.Show("User name is already in use, please choose a different user name.", "Attention!");
                    return;
                }
            }

            #endregion



            _context.Users.Add(user);
            _context.SaveChanges();

            FillUserDetails();
            FormReset();

            MessageBox.Show("New User is successfully added to the list.", "UPDATE");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure to permanently delete the selected user?", "Delete User", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                _context.Users.Remove(this.SelectedUser);
                _context.SaveChanges();

                FillUserDetails();
                FormReset();
                ButtonReset();


                MessageBox.Show("User is successfully removed from the list.", "Deleted");
            }

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!FormValidation())
            {
                return;
            }


            SelectedUser.FirstName = TxtFirstName.Text;
            SelectedUser.LastName = TxtLastName.Text;
            SelectedUser.UserName = TxtUserName.Text;
            SelectedUser.Password = TxtPassword.Text;

            _context.SaveChanges();

            FillUserDetails();
            FormReset();
            ButtonReset();

            MessageBox.Show("Selected user is successfully updated", "UPDATE");
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            FormReset();
            ButtonReset();
            DgvUser.Rows.Clear();

            List<Library.Models.User> users = _context.Users.Where(u => u.FirstName.Contains(TxtFN.Text) && u.UserName.Contains(TxtUN.Text)).ToList();

            foreach (var item in users)
            {
                DgvUser.Rows.Add(item.Id,
                                   item.FirstName,
                                   item.LastName,
                                   item.UserName,
                                   item.Password);
            }
        }

        #endregion


        #region Selecting users from DGV user list
        private void DgvUser_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BtnAdd.Visible = false;
            BtnUpdate.Visible = true;
            BtnDelete.Visible = true;

            FormReset();

            foreach (var item in _context.Users.ToList())
            {
                int Id = Convert.ToInt32(DgvUser.Rows[e.RowIndex].Cells[0].Value.ToString());

                this.SelectedUser = _context.Users.Find(Id);

                TxtFirstName.Text = SelectedUser.FirstName;
                TxtLastName.Text = SelectedUser.LastName;
                TxtUserName.Text = SelectedUser.UserName;
                TxtPassword.Text = SelectedUser.Password;

            }
        }

        #endregion


        #region Function for hiding passwords visibility with "*" character in DGV list
        private void DgvUser_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        #endregion




    }
}
