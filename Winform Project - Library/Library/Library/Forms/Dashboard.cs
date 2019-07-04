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

        private decimal totalPrice = 0;

        private Library.Models.Book SelectedBook;

        private decimal RemovedPrice;



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
            PnlNewOrder.BringToFront();



            FillCustomerList();
            FillBookList();


            LblCNOPriceNo.Text = "0";
            CmbCNOBook.DropDownHeight = CmbCNOBook.Font.Height * 5;
            CmbCNOCustomer.DropDownHeight = CmbCNOCustomer.Font.Height * 5;


            BtnNewOrder.BackColor = Color.DarkSlateGray;
            BtnReturnBook.BackColor = Color.LightSeaGreen;
            BtnTrackOrders.BackColor = Color.LightSeaGreen;


        }

        private void BtnReturnBook_Click(object sender, EventArgs e)
        {

            //PnlReturnBookBase.Visible = false;
            //PnlReturnBookBase.BringToFront();



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
                CmbCNOCustomer.Items.Add(item.FirstName + " " + item.LastName);
            }
            
        }

        private void FillBookList()
        {
            foreach(var item in _context.Books.ToList())
            {
                if(item.Count == 0)
                {
                    CmbCNOBook.Items.Remove(item.Name);
                }
                else
                {
                    CmbCNOBook.Items.Add(item.Name);
                }

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

            return true;
        }

        private bool ValidateBookCountAvailability()
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

            CmbCNOCustomer.Text = string.Empty;
            CmbCNOCustomer.Enabled = true;
            CmbCNOBook.Text = string.Empty;
            DateReturn.Value = DateTime.Now;
            NumCNOCount.Text = "1";
            TxtCNOPrice.Text = "0";

            PicCNOEmptyBasket.Visible = true;
            PicCNOFullBasket.Visible = false;


        }

        private void AddBtnResetForm()
        {
            LblCNOBook.ForeColor = SystemColors.ControlText;
            LblCNOCount.ForeColor = SystemColors.ControlText;
            LblCNOReturnDate.ForeColor = SystemColors.ControlText;

            CmbCNOBook.Text = string.Empty;
            DateReturn.Value = DateTime.Now;
            NumCNOCount.Text = "1";
            TxtCNOPrice.Text = "0";
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
           
            if (DateReturn.Value <= DateTime.Now.AddDays(7))
            {
                TxtCNOPrice.Text = (SelectedBook.Price * NumCNOCount.Value).ToString();
            }
            if (DateReturn.Value > DateTime.Now.AddDays(7) && DateReturn.Value <= DateTime.Now.AddDays(14))
            {
                TxtCNOPrice.Text = (SelectedBook.Price * 2 * NumCNOCount.Value).ToString();
            }
            if (DateReturn.Value > DateTime.Now.AddDays(14) && DateReturn.Value <= DateTime.Now.AddDays(21))
            {
                TxtCNOPrice.Text = (SelectedBook.Price * 3 * NumCNOCount.Value).ToString();
            }
            if (DateReturn.Value > DateTime.Now.AddDays(21) && DateReturn.Value <= DateTime.Now.AddMonths(1))
            {
                TxtCNOPrice.Text = (SelectedBook.Price * 4 * NumCNOCount.Value).ToString();
            }
            if (DateReturn.Value > DateTime.Now.AddMonths(1) && DateReturn.Value <= DateTime.Now.AddMonths(3))
            {
                TxtCNOPrice.Text = (SelectedBook.Price * 5 * NumCNOCount.Value).ToString();
            }

        }


        private void DateReturn_ValueChanged(object sender, EventArgs e)
        {
            CalcPriceWithReturnDate();
            
        }

        #endregion


        #region ADD - SUBMIT - DELETE BUTTON FUNCTION

        private void BtnCNOSubmit_Click(object sender, EventArgs e)
        {

            Order newOrder = new Order
            {
                CustomerId = _context.Customers.FirstOrDefault(c => c.FirstName + " " + c.LastName == CmbCNOCustomer.Text).Id,
                CreatedOn = DateTime.Now,
                TotalPrice = Convert.ToDecimal(LblCNOPriceNo.Text)
            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();


            
            for (int i=0; i< DgvCNOBooks.Rows.Count - 1; i++)
            {
                
                OrderItem orderItem = new OrderItem
                {
                    BookId = Convert.ToInt32(DgvCNOBooks.Rows[i].Cells[0].Value),
                    Count = Convert.ToInt32(DgvCNOBooks.Rows[i].Cells[2].Value),
                    Price = Convert.ToInt32(DgvCNOBooks.Rows[i].Cells[4].Value),
                    ReturnDate = Convert.ToDateTime(DgvCNOBooks.Rows[i].Cells[3].Value),
                    OrderId = newOrder.Id
                    
                };

                _context.OrderItems.Add(orderItem);
                _context.SaveChanges();

                this.totalPrice = 0;
                LblCNOPriceNo.Text = (this.totalPrice).ToString();

            }

            ResetForm();
            DgvCNOBooks.Rows.Clear();
            totalPrice = 0;

            MessageBox.Show("Order is successfully created.", "New Order");

            
        }

        private void BtnCNODelete_Click(object sender, EventArgs e)
        {
            if (DgvCNOBooks.SelectedRows.Count > 0)
            {
                DgvCNOBooks.Rows.RemoveAt(DgvCNOBooks.SelectedRows[0].Index);
                LblCNOPriceNo.Text = (Convert.ToDecimal(LblCNOPriceNo.Text) - this.RemovedPrice).ToString();
                this.totalPrice -= this.RemovedPrice;
            }

            BtnCNODelete.Visible = false;
        }

        private void BtnCNOAdd_Click(object sender, EventArgs e)
        {

            if (!Validation())
            {
                return;
            }

            if (!ValidateBookCountAvailability())
            {
                return;
            }

            PicCNOEmptyBasket.Visible = false;
            PicCNOFullBasket.Visible = true;

            var price = Convert.ToDecimal(TxtCNOPrice.Text);

            DgvCNOBooks.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";

            DgvCNOBooks.Rows.Add(SelectedBook.Id, SelectedBook.Name, NumCNOCount.Value, DateReturn.Value, price);


            SelectedBook.Count -= Convert.ToInt32(NumCNOCount.Value);


            CmbCNOCustomer.Enabled = false;
            CmbCNOBook.Text = string.Empty;
            NumCNOCount.Value = 0;
            TxtCNOPrice.Text = "0";
            BtnCNODelete.Visible = false;

            totalPrice += price;

            LblCNOPriceNo.Text = totalPrice.ToString();

            AddBtnResetForm();

        }

        #endregion


        #region SELECT ROW FROM DGV
        private void DgvCNOBooks_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.RemovedPrice = Convert.ToDecimal(DgvCNOBooks.Rows[e.RowIndex].Cells[4].Value.ToString());
            BtnCNODelete.Visible = true;

        }



        #endregion

        #endregion



        #region RETURN BOOK --- BUTTON

        //private void BtnRBSearch_Click(object sender, EventArgs e)
        //{
        //    List<Library.Models.OrderItem> orderFind = _context.OrderItems.Where(o => o.Order.Customer.FirstName.Contains(TxtRBFirstName.Text) && o.Order.Customer.LastName.Contains(TxtRBLastName.Text) && o.Order.Customer.PhoneNumber.Contains(TxtRBPhoneNo.Text)).ToList();



        //    MessageBox.Show(TxtRBFirstName.Text);


        //    foreach (var item in orderFind)
        //    {
        //        DgvRBCustomer.Rows.Add(item.Id,
        //                                item.Order.Customer.FirstName,
        //                                item.Order.Customer.LastName,
        //                                item.Book.Name,
        //                                item.Count,
        //                                item.ReturnDate,
        //                                item.Price);
        //    }
        //}



        #endregion

    }

}
