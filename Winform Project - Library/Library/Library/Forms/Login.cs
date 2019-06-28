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
    public partial class Login : Form
    {
        

        private readonly LibraryContext _context; 
        public Login()
        {

            InitializeComponent();

            _context = new LibraryContext();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            if (!_context.Users.Any(u => u.UserName == TxtUsername.Text))
            {
                LblUserName.ForeColor = Color.Red;
                MessageBox.Show("Please enter correct username.", "Incorrect value");
                return;
            }
            if(!_context.Users.Any(u=>u.Password == TxtPassword.Text))
            {
                LblUserName.ForeColor = SystemColors.ControlText;
                LblPassword.ForeColor = Color.Red;
                MessageBox.Show("Please enter correct password", "Incorrect value");
            }
            else
            {
                LblPassword.ForeColor = SystemColors.ControlText;

                

                Dashboard dashboard = new Dashboard(TxtUsername.Text);

                this.Hide();
                dashboard.ShowDialog();
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
