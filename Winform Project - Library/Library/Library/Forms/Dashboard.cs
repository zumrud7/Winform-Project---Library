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

        private decimal ReturnBookTotalPrice = 0;

        private Library.Models.Book SelectedBook;

        private decimal RemovedPrice;

        private Library.Models.OrderItem SelectedItem;


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
            Report acc = new Report();

            acc.ShowDialog();
        }

        #endregion


        #region LEFT MENU BUTTONS' FUNCTIONS - NEW ORDER/ RETURN BOOK/ TRACK ORDER

        private void BtnNewOrder_Click(object sender, EventArgs e)
        {

            PnlNewOrder.Visible = true;
            PnlTrackOrders.Visible = false;
            PnlReturnBook.Visible = false;



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
            PnlNewOrder.Visible = false;
            PnlReturnBook.Visible = true;
            PnlTrackOrders.Visible = false;



            BtnNewOrder.BackColor = Color.LightSeaGreen;
            BtnReturnBook.BackColor = Color.DarkSlateGray;
            BtnTrackOrders.BackColor = Color.LightSeaGreen;
        }

        private void BtnTrackOrders_Click(object sender, EventArgs e)
        {
            PnlTrackOrders.Visible = true;
            PnlNewOrder.Visible = false;
            PnlReturnBook.Visible = false;

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
                if (item.Count == 0)
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

        #region FILL DGV ORDER LIST
        private void FillOrderList()
        {
            DgvRBCustomer.Rows.Clear();

            DgvRBCustomer.Columns[5].DefaultCellStyle.Format = "dd-MM-yyyy";
            DgvRBCustomer.Columns[6].DefaultCellStyle.Format = "dd-MM-yyyy";

            DgvRBCustomer.Rows.Clear();

            List<OrderItem> orders = _context.OrderItems.Include("Book").Include("Order").Include("Order.Customer").Where(o => o.Order.Customer.FirstName.Contains(TxtRBFirstName.Text) && o.Order.Customer.LastName.Contains(TxtRBLastName.Text) && o.Order.Customer.PhoneNumber.Contains(TxtRBPhoneNo.Text)).ToList();

            foreach (var item in orders)
            {
                if (item.isCompleted == false)
                {
                    DgvRBCustomer.Rows.Add(item.Id,
                                        item.Order.Customer.FirstName,
                                        item.Order.Customer.LastName,
                                        item.Book.Name,
                                        item.Count,
                                        item.Order.CreatedOn,
                                        item.ReturnDate,
                                        item.Price);
                }

            }

        }

        #endregion

        #region DGV ROW SELECT
        private void DgvRBCustomer_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            int Id = Convert.ToInt32(DgvRBCustomer.Rows[e.RowIndex].Cells[0].Value.ToString());

            SelectedItem = _context.OrderItems.Find(Id);

            TxtRBBookName.Text = SelectedItem.Book.Name;
            NumRBCount.Value = SelectedItem.Count;
            ReturnBookTotalPrice = SelectedItem.Price;
            DPRBReturn.Value = SelectedItem.ReturnDate;


            LblRBTotalPrice.Text = (ReturnBookTotalPrice).ToString();

        }


        #endregion

        #region VALIDATION / RESET / CALCULATION METHODS
        private bool ValidateNumCount()
        {
            if (NumRBCount.Value == 0)
            {
                LblRBCount.ForeColor = Color.Red;
                MessageBox.Show("Count cannot be 0", "Attention");
                NumRBCount.Value = SelectedItem.Count;
                return false;
            }

            if (NumRBCount.Value > SelectedItem.Count)
            {
                LblRBCount.ForeColor = Color.Red;
                MessageBox.Show("Selected count cannot be more than booked count", "Attention");
                NumRBCount.Value = SelectedItem.Count;
                return false;
            }

            LblRBCount.ForeColor = SystemColors.ControlText;
            return true;
        }

        private void ReturnPriceCalcWithCount()
        {
            ReturnBookTotalPrice = SelectedItem.Book.Price * Convert.ToDecimal(NumRBCount.Value);
            LblRBTotalPrice.Text = ReturnBookTotalPrice.ToString();

        }

        private void ResetReturnBookForm()
        {

            DgvRBCustomer.Rows.Clear();

            TxtRBFirstName.Text = string.Empty;
            TxtRBLastName.Text = string.Empty;
            TxtRBBookName.Text = string.Empty;
            NumRBCount.Value = 1;
            ReturnBookTotalPrice = 0;
            LblRBTotalPrice.Text = "0";
            DPRBReturn.Value = DateTime.Now;


        }

        private void ReturnPriceCalcWithDate()
        {
            if (DPRBReturn.Value > SelectedItem.Order.CreatedOn && DPRBReturn.Value < SelectedItem.ReturnDate)
            {

                if (DPRBReturn.Value > SelectedItem.Order.CreatedOn.AddDays(7) && DPRBReturn.Value <= SelectedItem.Order.CreatedOn.AddDays(14))
                {
                    ReturnBookTotalPrice = 0;
                    ReturnBookTotalPrice = SelectedItem.Book.Price * 2 * NumRBCount.Value;
                    LblRBTotalPrice.Text = ReturnBookTotalPrice.ToString();

                }
                else if (DPRBReturn.Value > SelectedItem.Order.CreatedOn.AddDays(14) && DPRBReturn.Value <= SelectedItem.Order.CreatedOn.AddDays(21))
                {
                    ReturnBookTotalPrice = 0;
                    ReturnBookTotalPrice = SelectedItem.Book.Price * 3 * NumRBCount.Value;
                    LblRBTotalPrice.Text = ReturnBookTotalPrice.ToString();

                }
                else if (DPRBReturn.Value > SelectedItem.Order.CreatedOn.AddDays(21) && DPRBReturn.Value <= SelectedItem.Order.CreatedOn.AddMonths(1))
                {
                    ReturnBookTotalPrice = 0;
                    ReturnBookTotalPrice = SelectedItem.Book.Price * 4 * NumRBCount.Value;
                    LblRBTotalPrice.Text = ReturnBookTotalPrice.ToString();

                }
                else if (DPRBReturn.Value > SelectedItem.Order.CreatedOn.AddMonths(1) && DPRBReturn.Value <= SelectedItem.Order.CreatedOn.AddMonths(3))
                {
                    ReturnBookTotalPrice = 0;
                    ReturnBookTotalPrice = SelectedItem.Book.Price * 5 * NumRBCount.Value;
                    LblRBTotalPrice.Text = ReturnBookTotalPrice.ToString();

                }
                ReturnBookTotalPrice = 0;
                ReturnBookTotalPrice = SelectedItem.Book.Price * NumRBCount.Value;

                LblRBTotalPrice.Text = ReturnBookTotalPrice.ToString();

            }

            else if (DPRBReturn.Value > SelectedItem.Order.CreatedOn.AddDays(7) && DPRBReturn.Value <= SelectedItem.Order.CreatedOn.AddDays(14))
            {
                ReturnBookTotalPrice = 0;
                ReturnBookTotalPrice = SelectedItem.Book.Price * 2 * NumRBCount.Value;
                LblRBTotalPrice.Text = ReturnBookTotalPrice.ToString();

            }
            else if (DPRBReturn.Value > SelectedItem.Order.CreatedOn.AddDays(14) && DPRBReturn.Value <= SelectedItem.Order.CreatedOn.AddDays(21))
            {
                ReturnBookTotalPrice = 0;
                ReturnBookTotalPrice = SelectedItem.Book.Price * 3 * NumRBCount.Value;
                LblRBTotalPrice.Text = ReturnBookTotalPrice.ToString();

            }
            else if (DPRBReturn.Value > SelectedItem.Order.CreatedOn.AddDays(21) && DPRBReturn.Value <= SelectedItem.Order.CreatedOn.AddMonths(1))
            {
                ReturnBookTotalPrice = 0;
                ReturnBookTotalPrice = SelectedItem.Book.Price * 4 * NumRBCount.Value;
                LblRBTotalPrice.Text = ReturnBookTotalPrice.ToString();

            }
            else if (DPRBReturn.Value > SelectedItem.Order.CreatedOn.AddMonths(1) && DPRBReturn.Value <= SelectedItem.Order.CreatedOn.AddMonths(3))
            {
                ReturnBookTotalPrice = 0;
                ReturnBookTotalPrice = SelectedItem.Book.Price * 5 * NumRBCount.Value;
                LblRBTotalPrice.Text = ReturnBookTotalPrice.ToString();

            }
            else if (DPRBReturn.Value > SelectedItem.ReturnDate)
            {

                var span = DPRBReturn.Value - SelectedItem.ReturnDate;
                int days = span.Days;
                //MessageBox.Show("Delayed days " + days.ToString());

                var fine = days * (Convert.ToInt32(SelectedItem.Book.Price) * 0.5);
                //MessageBox.Show("Applied fine " + fine.ToString());

                ReturnBookTotalPrice += Convert.ToDecimal(fine);
                LblRBTotalPrice.Text = ReturnBookTotalPrice.ToString();
            }



        }

        #endregion

        #region DATE PIICKER AND NUMERIC-UP-DOWN VALUE CHANGE
        private void DPRBReturn_ValueChanged(object sender, EventArgs e)
        {
            ReturnPriceCalcWithDate();
        }

        private void NumRBCount_ValueChanged(object sender, EventArgs e)
        {
            if (!ValidateNumCount())
            {
                return;
            };

            ReturnPriceCalcWithCount();
            ReturnPriceCalcWithDate();

        }

        #endregion

        #region BUTTON FUNCTIONS
        private void BtnRBReturnBook_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure to complete the booking?", "Complete", MessageBoxButtons.YesNo);

            if(r == DialogResult.Yes)
            {
                MessageBox.Show("Booking is successfully completed.", "Update");
            }

            SelectedItem.isCompleted = true;
            SelectedItem.Book.Count += Convert.ToInt32(NumRBCount.Value);

            _context.SaveChanges();

            this.ReturnBookTotalPrice = 0;
            LblRBTotalPrice.Text = (this.ReturnBookTotalPrice).ToString();

            ResetReturnBookForm();
        }

        private void BtnRBSearch_Click(object sender, EventArgs e)
        {
            FillOrderList();
        }

        #endregion


        #endregion


        #region TRACK ORDERS --- BUTTON

        #region FILL DGV ORDER LIST ACCORDING TO RETURN DATE
        private void FillTodayOrderList()
        {
            DgvTOTodayOrderList.Rows.Clear();

            DgvTOTodayOrderList.Columns[5].DefaultCellStyle.Format = "dd-MM-yyyy";
            DgvTOTodayOrderList.Columns[6].DefaultCellStyle.Format = "dd-MM-yyyy";

            var today = DateTime.Now.Date;
            var tomorrow = today.AddHours(24);

            List<OrderItem> orderitems = _context.OrderItems.Include("Book").Include("Order").Include("Order.Customer").Where(o => o.ReturnDate > today && o.ReturnDate < tomorrow && o.isCompleted == false).ToList();

            foreach (var item in orderitems)
            {
                    DgvTOTodayOrderList.Rows.Add(item.Id,
                                        item.Order.Customer.FirstName,
                                        item.Order.Customer.LastName,
                                        item.Book.Name,
                                        item.Count,
                                        item.Order.CreatedOn,
                                        item.ReturnDate,
                                        item.Price);
             
            }

        }


        private void FillDelayedOrderList()
        {
            DgvTODelayedOrderList.Rows.Clear();

            DgvTODelayedOrderList.Columns[5].DefaultCellStyle.Format = "dd-MM-yyyy";
            DgvTODelayedOrderList.Columns[6].DefaultCellStyle.Format = "dd-MM-yyyy";

            var baselineDate = DateTime.Now.AddHours(-24);

            List<OrderItem> orderitems = _context.OrderItems.Include("Book").Include("Order").Include("Order.Customer").Where(o => o.ReturnDate < baselineDate && o.isCompleted == false).ToList();

            foreach (var item in orderitems)
            {
                DgvTODelayedOrderList.Rows.Add(item.Id,
                                    item.Order.Customer.FirstName,
                                    item.Order.Customer.LastName,
                                    item.Book.Name,
                                    item.Count,
                                    item.Order.CreatedOn,
                                    item.ReturnDate,
                                    item.Price);

            }

        }


        private void FillTomorrowOrderList()
        {
            DgvTOTomorrowOrderList.Rows.Clear();

            DgvTOTomorrowOrderList.Columns[5].DefaultCellStyle.Format = "dd-MM-yyyy";
            DgvTOTomorrowOrderList.Columns[6].DefaultCellStyle.Format = "dd-MM-yyyy";

            var today = DateTime.Now.Date;
            var StartDate = today.AddHours(24);
            var EndDate = today.AddHours(48);

            List<OrderItem> orderitems = _context.OrderItems.Include("Book").Include("Order").Include("Order.Customer").Where(o => o.ReturnDate > StartDate && o.ReturnDate < EndDate && o.isCompleted == false).ToList();

            foreach (var item in orderitems)
            {
                DgvTOTomorrowOrderList.Rows.Add(item.Id,
                                    item.Order.Customer.FirstName,
                                    item.Order.Customer.LastName,
                                    item.Book.Name,
                                    item.Count,
                                    item.Order.CreatedOn,
                                    item.ReturnDate,
                                    item.Price);

            }

        }


        #endregion


        #region BUTTON FUNCTIONS

        private void BtnToday_Click(object sender, EventArgs e)
        {
            DgvTODelayedOrderList.Visible = false;
            DgvTOTodayOrderList.Visible = true;
            DgvTOTomorrowOrderList.Visible = false;

            BtnToday.FlatAppearance.BorderSize = 1;
            BtnToday.FlatAppearance.BorderColor = SystemColors.ControlText;
            BtnTomorrow.FlatAppearance.BorderSize = 0;
            BtnDelayed.FlatAppearance.BorderSize = 0;

            FillTodayOrderList();

        }

        private void BtnTomorrow_Click(object sender, EventArgs e)
        {
            DgvTODelayedOrderList.Visible = false;
            DgvTOTodayOrderList.Visible = false;
            DgvTOTomorrowOrderList.Visible = true;

            BtnTomorrow.FlatAppearance.BorderSize = 1;
            BtnTomorrow.FlatAppearance.BorderColor = SystemColors.ControlText;
            BtnToday.FlatAppearance.BorderSize = 0;
            BtnDelayed.FlatAppearance.BorderSize = 0;

            FillTomorrowOrderList();

            
        }

        private void BtnDelayed_Click(object sender, EventArgs e)
        {
            DgvTODelayedOrderList.Visible = true;
            DgvTOTodayOrderList.Visible = false;
            DgvTOTomorrowOrderList.Visible = false;

            BtnDelayed.FlatAppearance.BorderSize = 1;
            BtnDelayed.FlatAppearance.BorderColor = SystemColors.ControlText;
            BtnTomorrow.FlatAppearance.BorderSize = 0;
            BtnToday.FlatAppearance.BorderSize = 0;

            FillDelayedOrderList();
        }

        #endregion


        #endregion

    }

}
