using Library.DAL;
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
    public partial class Dashboard : Form
    {

        private readonly LibraryContext _context;
        public Dashboard(string UserFullName)
        {
            InitializeComponent();
            _context = new LibraryContext();

            LblUserName.Text = UserFullName;

        }


        private void BtnLogout_Click(object sender, EventArgs e)
        {

            Login login = new Login();

            this.Hide();
            login.Show();

        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void BtnHome_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            User user = new User();

            user.ShowDialog();
        }

        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();

            customer.ShowDialog();
        }

        private void BtnBook_Click(object sender, EventArgs e)
        {
            Book book = new Book();

            book.ShowDialog();
        }

        private void BtnAccount_Click(object sender, EventArgs e)
        {
            Account acc = new Account();

            acc.ShowDialog();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
