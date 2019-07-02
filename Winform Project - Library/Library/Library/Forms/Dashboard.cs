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
using Library.Models;

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

        #region LOGOUT EXIT BUTTON FUNCTIONS

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

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion


        #region TOP MENU BUTTONS' FUNCTIONS - CUSTOMER/ BOOK/ USER/ ACCOUNT
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

        #endregion


        #region LEFT MENU BUTTONS' FUNCTIONS - NEW ORDER/ RETURN BOOK/ TRACK ORDER

        private void BtnNewOrder_Click(object sender, EventArgs e)
        {
            PnlNewOrder.Visible = true;

            FillCustomerList();
            FillBookList();


            TxtCNOPrice.Text = "0";
            CmbCNOBook.DropDownHeight = CmbCNOBook.Font.Height * 5;
            CmbCNOCustomer.DropDownHeight = CmbCNOCustomer.Font.Height * 5;


            BtnNewOrder.BackColor = Color.DarkSlateGray;
            BtnReturnBook.BackColor = Color.LightSeaGreen;
            BtnTrackOrders.BackColor = Color.LightSeaGreen;


        }

        private void BtnReturnBook_Click(object sender, EventArgs e)
        {
            PnlNewOrder.Visible = false;


            BtnNewOrder.BackColor = Color.LightSeaGreen;
            BtnReturnBook.BackColor = Color.DarkSlateGray;
            BtnTrackOrders.BackColor = Color.LightSeaGreen;
        }

        private void BtnTrackOrders_Click(object sender, EventArgs e)
        {
            PnlNewOrder.Visible = false;


            BtnNewOrder.BackColor = Color.LightSeaGreen;
            BtnReturnBook.BackColor = Color.LightSeaGreen;
            BtnTrackOrders.BackColor = Color.DarkSlateGray;
        }


        #endregion


        #region CREATE NEW ORDER --- BUTTON


        #region FUNCTIONS TO FILL COMBOBOXES
        private void FillCustomerList()
        {
            foreach(var item in _context.Customers.ToList())
            {
                CmbCNOCustomer.Items.Add(item.FirstName);
            }
            
        }

        private void FillBookList()
        {
            foreach(var item in _context.Books.ToList())
            {
                CmbCNOBook.Items.Add(item.Name);
            }
        }


        #endregion


        #region FUNCTION TO FILL DATAGRIDVIEW

        //private void FillOrderItemList()
        //{
        //    DgvOrderItemList.Rows.Clear();

        //    foreach (var item in _context.OrderItems.ToList())
        //    {
        //        DgvOrderItemList.Rows.Add(item.Id,
        //                                   item.CustomerId,
        //                                   item.Customer.FirstName,
        //                                   item.Customer.LastName,
        //                                   item.BookId,
        //                                   item.Book.Name,
        //                                   item.Count,
        //                                   item.Price,
        //                                   item.ReturnPeriodId,
        //                                   item.ReturnPeriod.ReturnDate);
        //    }
        //}

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

            if (DateReturn.Value == DateTime.Now)
            {
                LblCNOCustomer.ForeColor = SystemColors.ControlText;
                LblCNOBook.ForeColor = SystemColors.ControlText;
                LblCNOCount.ForeColor = SystemColors.ControlText;
                LblCNOReturnDate.ForeColor = Color.Red;

                return false;

            }

            if(DateReturn.Value < DateCreate.Value)
            {
                LblCNOCustomer.ForeColor = SystemColors.ControlText;
                LblCNOBook.ForeColor = SystemColors.ControlText;
                LblCNOCount.ForeColor = SystemColors.ControlText;
                LblCNOReturnDate.ForeColor = Color.Red;

                MessageBox.Show("Return date cannot be earlier than order create date", "Attention");

                return false;
            }
            return true;
        }

        private bool ValidatePrice()
        {

            if (NumCNOCount.Value > SelectedBook.Count)
            {
                LblCNOCount.ForeColor = Color.Red;
                MessageBox.Show("Selected book count exceeds the available count.", "Attention");
                return false;
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
            DateReturn.Value = DateTime.Now;
            NumCNOCount.Text = "0";
            TxtCNOPrice.Text = "0";
            DateCreate.Value = DateTime.Now;

        }

        #endregion


        #region DISPLAY BOOK PRICE IN PRICE TEXTBOX
        private void DisplayBookPrice()
        {
            
                int Id = _context.Books.FirstOrDefault(b => b.Name == CmbCNOBook.Text).Id;
                SelectedBook = _context.Books.Find(Id);

                TxtCNOPrice.Text = SelectedBook.Price.ToString();
         
        }

        private void CmbCNOBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayBookPrice();
        }

        #endregion

        #region SET LIMITATIONS FOR CREATE DATE AND RETURN DATE

        

        #endregion


        #region CALC BOOK PRICE ON SELECTION OF BOOK COUNT
        private void CalcPriceWithCount()
        {

            TxtCNOPrice.Text = (SelectedBook.Price * Convert.ToDecimal(NumCNOCount.Value)).ToString();

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
           
            if (DateReturn.Value <= DateCreate.Value.AddDays(7))
            {
                TxtCNOPrice.Text = (SelectedBook.Price * NumCNOCount.Value).ToString();
            }
            if (DateReturn.Value > DateCreate.Value.AddDays(7) && DateReturn.Value <= DateCreate.Value.AddDays(14))
            {
                TxtCNOPrice.Text = (SelectedBook.Price * 2 * NumCNOCount.Value).ToString();
            }
            if (DateReturn.Value > DateCreate.Value.AddDays(14) && DateReturn.Value <= DateCreate.Value.AddDays(21))
            {
                TxtCNOPrice.Text = (SelectedBook.Price * 3 * NumCNOCount.Value).ToString();
            }
            if (DateReturn.Value > DateCreate.Value.AddDays(21) && DateReturn.Value <= DateCreate.Value.AddMonths(1))
            {
                TxtCNOPrice.Text = (SelectedBook.Price * 4 * NumCNOCount.Value).ToString();
            }
            if (DateReturn.Value > DateCreate.Value.AddMonths(1) && DateReturn.Value <= DateCreate.Value.AddMonths(3))
            {
                TxtCNOPrice.Text = (SelectedBook.Price * 5 * NumCNOCount.Value).ToString();
            }

        }



        private void DateReturn_ValueChanged(object sender, EventArgs e)
        {
            CalcPriceWithReturnDate();
        }

        #endregion




        #region SUBMIT - CLEAR BUTTON FUNCTION

        private void BtnCNOClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }


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

            //OrderItem order = new OrderItem
            //{
            //    Date = DateCreate.Value,
            //    CustomerId = _context.Customers.FirstOrDefault(c => c.FirstName == CmbCNOCustomer.Text).Id,
            //    BookId = _context.Books.FirstOrDefault(b => b.Name == CmbCNOBook.Text).Id,
            //    Count = Convert.ToInt32(NumCNOCount.Value),
            //    Price = Convert.ToDecimal(TxtCNOPrice.Text),
            //    ReturnPeriodId = _context.ReturnPeriods.FirstOrDefault(r => r.ReturnDate == DateReturn.Value).Id

            //};

            //_context.OrderItems.Add(order);
            //_context.SaveChanges();


            //FillOrderItemList();
            ResetForm();
           
            MessageBox.Show("Order is successfully created.", "New Order");

        }




        #endregion

        #endregion

        private void PnlCreateOrder_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
