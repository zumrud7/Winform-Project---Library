using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.DAL;
using Library.Models;

namespace Library.Forms
{
    public partial class Test : Form
    {
        private readonly LibraryContext _context;

        private Library.Models.OrderItem SelectedItem;

        private decimal totalPrice;
        public Test()
        {
            InitializeComponent();

            _context = new LibraryContext();
        }

        #region RETURN BOOK BUTTON

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

        private void BtnRBSearch_Click(object sender, EventArgs e)
        {
            FillOrderList();
        }

        private void DgvRBCustomer_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            int Id = Convert.ToInt32(DgvRBCustomer.Rows[e.RowIndex].Cells[0].Value.ToString());

            SelectedItem = _context.OrderItems.Find(Id);

            TxtRBBookName.Text = SelectedItem.Book.Name;
            NumRBCount.Value = SelectedItem.Count;
            totalPrice = SelectedItem.Price;
            DPRBReturn.Value = SelectedItem.ReturnDate;


            LblRBTotalPrice.Text = (totalPrice).ToString();

        }

        #region VALIDATION AND CALCULATION METHODS
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
            totalPrice = SelectedItem.Book.Price * Convert.ToDecimal(NumRBCount.Value);
            LblRBTotalPrice.Text = totalPrice.ToString();

        }

        private void ResetReturnBookForm()
        {

            DgvRBCustomer.Rows.Clear();

            TxtRBFirstName.Text = string.Empty;
            TxtRBLastName.Text = string.Empty;
            TxtRBBookName.Text = string.Empty;
            NumRBCount.Value = 1;
            totalPrice = 0;
            DPRBReturn.Value = DateTime.Now;


        }

        private void ReturnPriceCalcWithDate()
        {
            if (DPRBReturn.Value > SelectedItem.Order.CreatedOn && DPRBReturn.Value < SelectedItem.ReturnDate)
            {

                if (DPRBReturn.Value > SelectedItem.Order.CreatedOn.AddDays(7) && DPRBReturn.Value <= SelectedItem.Order.CreatedOn.AddDays(14))
                {
                    totalPrice = 0;
                    totalPrice = SelectedItem.Book.Price * 2 * NumRBCount.Value;
                    LblRBTotalPrice.Text = totalPrice.ToString();

                }
                else if (DPRBReturn.Value > SelectedItem.Order.CreatedOn.AddDays(14) && DPRBReturn.Value <= SelectedItem.Order.CreatedOn.AddDays(21))
                {
                    totalPrice = 0;
                    totalPrice = SelectedItem.Book.Price * 3 * NumRBCount.Value;
                    LblRBTotalPrice.Text = totalPrice.ToString();

                }
                else if (DPRBReturn.Value > SelectedItem.Order.CreatedOn.AddDays(21) && DPRBReturn.Value <= SelectedItem.Order.CreatedOn.AddMonths(1))
                {
                    totalPrice = 0;
                    totalPrice = SelectedItem.Book.Price * 4 * NumRBCount.Value;
                    LblRBTotalPrice.Text = totalPrice.ToString();

                }
                else if (DPRBReturn.Value > SelectedItem.Order.CreatedOn.AddMonths(1) && DPRBReturn.Value <= SelectedItem.Order.CreatedOn.AddMonths(3))
                {
                    totalPrice = 0;
                    totalPrice = SelectedItem.Book.Price * 5 * NumRBCount.Value;
                    LblRBTotalPrice.Text = totalPrice.ToString();

                }
                totalPrice = 0;
                totalPrice = SelectedItem.Book.Price * NumRBCount.Value;

                LblRBTotalPrice.Text = totalPrice.ToString();

            }

            else if (DPRBReturn.Value > SelectedItem.Order.CreatedOn.AddDays(7) && DPRBReturn.Value <= SelectedItem.Order.CreatedOn.AddDays(14))
            {
                totalPrice = 0;
                totalPrice = SelectedItem.Book.Price * 2 * NumRBCount.Value;
                LblRBTotalPrice.Text = totalPrice.ToString();

            }
            else if (DPRBReturn.Value > SelectedItem.Order.CreatedOn.AddDays(14) && DPRBReturn.Value <= SelectedItem.Order.CreatedOn.AddDays(21))
            {
                totalPrice = 0;
                totalPrice = SelectedItem.Book.Price * 3 * NumRBCount.Value;
                LblRBTotalPrice.Text = totalPrice.ToString();

            }
            else if (DPRBReturn.Value > SelectedItem.Order.CreatedOn.AddDays(21) && DPRBReturn.Value <= SelectedItem.Order.CreatedOn.AddMonths(1))
            {
                totalPrice = 0;
                totalPrice = SelectedItem.Book.Price * 4 * NumRBCount.Value;
                LblRBTotalPrice.Text = totalPrice.ToString();

            }
            else if (DPRBReturn.Value > SelectedItem.Order.CreatedOn.AddMonths(1) && DPRBReturn.Value <= SelectedItem.Order.CreatedOn.AddMonths(3))
            {
                totalPrice = 0;
                totalPrice = SelectedItem.Book.Price * 5 * NumRBCount.Value;
                LblRBTotalPrice.Text = totalPrice.ToString();

            }
            else if (DPRBReturn.Value > SelectedItem.ReturnDate)
            {

                var span = DPRBReturn.Value - SelectedItem.ReturnDate;
                int days = span.Days;
                MessageBox.Show("Delayed days "+days.ToString());

                var fine = days * (Convert.ToInt32(SelectedItem.Book.Price) * 0.5);
                MessageBox.Show("Applied fine "+fine.ToString());

                totalPrice += Convert.ToDecimal(fine);
                LblRBTotalPrice.Text = totalPrice.ToString();
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

        private void BtnRBReturnBook_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure to complete booking?", "Complete");

            SelectedItem.isCompleted = true;
            SelectedItem.Book.Count += Convert.ToInt32(NumRBCount.Value);

            _context.SaveChanges();

            ResetReturnBookForm();
        }

        #endregion
    }
}
