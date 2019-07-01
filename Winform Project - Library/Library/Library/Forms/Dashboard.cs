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

        private Library.Models.Book SelectedBook;
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

        private void BtnNewOrder_Click(object sender, EventArgs e)
        {
            PnlNewOrder.Visible = true;

            FillCustomerList();
            FillBookList();
            FillReturnPeriod();

            TxtCNOPrice.Text = "0";
            CmbCNOBook.DropDownHeight = CmbCNOBook.Font.Height * 5;
            CmbCNOCustomer.DropDownHeight = CmbCNOCustomer.Font.Height * 5;
            CmbCNOReturnDate.DropDownHeight = CmbCNOReturnDate.Font.Height * 5;
        }

        private void BtnReturnBook_Click(object sender, EventArgs e)
        {
            PnlNewOrder.Visible = false;
        }

        private void BtnTrackOrders_Click(object sender, EventArgs e)
        {
            PnlNewOrder.Visible = false;
        }



        #region CREATE NEW ORDER --- BUTTON


        #region FUNCTIONS TO FILL COMBOBOXES
        private void FillCustomerList()
        {
            foreach(var item in _context.Customers.ToList())
            {
                CmbCNOCustomer.Items.Add(item.FirstName + " " + item.LastName);
            }
            
        }

        private void FillBookList()
        {
            foreach(var item in _context.Books.ToList())
            {
                CmbCNOBook.Items.Add(item.Name);
            }
        }

        private void FillReturnPeriod()
        {
            foreach(var item in _context.ReturnPeriods.ToList())
            {
                CmbCNOReturnDate.Items.Add(item.Name);
            }
        }

        #endregion


        #region FORM VALIDATION AND RESET METHODS

        private bool Validation()
        {
            if (string.IsNullOrEmpty(CmbCNOCustomer.Text))
            {
                LblCNOCustomer.ForeColor = Color.Red;
                LblCNOBook.ForeColor = SystemColors.ControlText;
                LblCNOCount.ForeColor = SystemColors.ControlText;
                LblCNOReturnDate.ForeColor = SystemColors.ControlText;

                return false;
            }

            if (string.IsNullOrEmpty(CmbCNOBook.Text))
            {
                LblCNOCustomer.ForeColor = SystemColors.ControlText;
                LblCNOBook.ForeColor = Color.Red;
                LblCNOCount.ForeColor = SystemColors.ControlText;
                LblCNOReturnDate.ForeColor = SystemColors.ControlText;

                return false;
            }

            if(NumCNOCount.Value == 0)
            {
                LblCNOCustomer.ForeColor = SystemColors.ControlText;
                LblCNOBook.ForeColor = SystemColors.ControlText;
                LblCNOCount.ForeColor = Color.Red;
                LblCNOReturnDate.ForeColor = SystemColors.ControlText;

                return false;
            }

            if (string.IsNullOrEmpty(CmbCNOReturnDate.Text))
            {
                LblCNOCustomer.ForeColor = SystemColors.ControlText;
                LblCNOBook.ForeColor = SystemColors.ControlText;
                LblCNOCount.ForeColor = SystemColors.ControlText;
                LblCNOReturnDate.ForeColor = Color.Red;

                return false;

            }
            return true;
        }

        private bool ValidatePrice()
        {

            foreach (var item in _context.Books.ToList())
            {
                item.Id = _context.Books.FirstOrDefault(b => b.Name == CmbCNOBook.Text).Id;
                
                if(item.Count < Convert.ToInt32(NumCNOCount.Text))
                {
                    LblCNOCount.ForeColor = Color.Red;
                    MessageBox.Show("Selected book count exceeds the available count.", "Attention");
                    return false;
                }

            }
            return true;

        }

        private void ResetForm()
        {
            LblCNOCustomer.ForeColor = SystemColors.ControlText;
            LblCNOBook.ForeColor = SystemColors.ControlText;
            LblCNOCount.ForeColor = SystemColors.ControlText;
            LblCNOReturnDate.ForeColor = SystemColors.ControlText;
            LblCNOPrice.ForeColor = SystemColors.ControlText;

            CmbCNOCustomer.Text = string.Empty;
            CmbCNOBook.Text = string.Empty;
            CmbCNOReturnDate.Text = string.Empty;
            NumCNOCount.Text = "0";
            TxtCNOPrice.Text = "0";
            DateCreate.Value = DateTime.Now;

        }

        #endregion


        #region DISPLAY BOOK PRICE IN PRICE TEXTBOX
        private void DisplayBookPrice()
        {
            //foreach (var item in _context.Books.ToList())
            //{
                int Id = _context.Books.FirstOrDefault(b => b.Name == CmbCNOBook.Text).Id;
                SelectedBook = _context.Books.Find(Id);


                TxtCNOPrice.Text = SelectedBook.Price.ToString();
            //}

        }

        private void CmbCNOBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayBookPrice();
        }

        #endregion


        #region CALC BOOK PRICE ON SELECTION OF BOOK COUNT
        private void CalcPriceWithCount()
        {

            TxtCNOPrice.Text = (SelectedBook.Price * NumCNOCount.Value).ToString();

        }

        private void NumCNOCount_ValueChanged(object sender, EventArgs e)
        {
            CalcPriceWithCount();
            CalcPriceWithReturnDate();

        }

        #endregion


        #region CALC BOOK PRICE ON SELECTION OF RETURN DATE
        private void CalcPriceWithReturnDate()
        {
            if (CmbCNOReturnDate.Text == "1 Week")
            {
                TxtCNOPrice.Text = (SelectedBook.Price * NumCNOCount.Value).ToString();
            }
            if (CmbCNOReturnDate.Text == "2 Weeks")
            {
                TxtCNOPrice.Text = (SelectedBook.Price * 2 * NumCNOCount.Value).ToString();
            }
            if (CmbCNOReturnDate.Text == "3 Weeks")
            {
                TxtCNOPrice.Text = (SelectedBook.Price * 3 * NumCNOCount.Value).ToString();
            }
            if (CmbCNOReturnDate.Text == "1 Month")
            {
                TxtCNOPrice.Text = (SelectedBook.Price * 4 * NumCNOCount.Value).ToString();
            }
            if (CmbCNOReturnDate.Text == "3 Months")
            {
                TxtCNOPrice.Text = (SelectedBook.Price * 5 * NumCNOCount.Value).ToString();
            }

        }

        private void CmbCNOReturnDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcPriceWithReturnDate();
        }

        #endregion


        #region SUBMIT BUTTON FUNCTION
        private void BtnCNOSubmit_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                return;
            }

            if (!ValidatePrice())
            {
                return;
            }

            ResetForm();

            MessageBox.Show("Order is successfully created.", "New Order");

        }





        #endregion

        #endregion

      
    }

}
