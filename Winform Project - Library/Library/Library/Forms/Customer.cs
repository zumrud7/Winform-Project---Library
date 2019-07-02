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

    public partial class Customer : Form
    {
        private readonly LibraryContext _context;

        private Library.Models.Customer SelectedCustomer;

        public Customer()
        {
            InitializeComponent();
            _context = new LibraryContext();

            FillCustomerList();
        }


        #region FILL DGV CUSTOMER LIST
        private void FillCustomerList()
        {
            DgvCustomer.Rows.Clear();

            foreach(var item in _context.Customers.ToList())
            {
                DgvCustomer.Rows.Add(item.Id,
                                     item.FirstName,
                                     item.LastName,
                                     item.PhoneNumber,
                                     item.Email);
            }
        }

        #endregion


        #region VALIDATION AND RESET METHODS

        private bool Validation()
        {
            if (string.IsNullOrEmpty(TxtFirstName.Text))
            {
                LblFirstName.ForeColor = Color.Red;
                LblLastName.ForeColor = SystemColors.ControlText;
                LblPhoneNo.ForeColor = SystemColors.ControlText;
                LblEmail.ForeColor = SystemColors.ControlText;

                return false;
            }
            if (string.IsNullOrEmpty(TxtLastName.Text))
            {
                LblFirstName.ForeColor = SystemColors.ControlText;
                LblLastName.ForeColor = Color.Red;
                LblPhoneNo.ForeColor = SystemColors.ControlText;
                LblEmail.ForeColor = SystemColors.ControlText;

                return false;
            }
            if (string.IsNullOrEmpty(TxtPhoneNo.Text))
            {
                LblFirstName.ForeColor = SystemColors.ControlText;
                LblLastName.ForeColor = SystemColors.ControlText;
                LblPhoneNo.ForeColor = Color.Red;
                LblEmail.ForeColor = SystemColors.ControlText;

                return false;

            }
            if (string.IsNullOrEmpty(TxtEmail.Text))
            {
                LblFirstName.ForeColor = SystemColors.ControlText;
                LblLastName.ForeColor = SystemColors.ControlText;
                LblPhoneNo.ForeColor = SystemColors.ControlText;
                LblEmail.ForeColor = Color.Red;

                return false;
            }

            return true;
        }

        private void ResetForm()
        {
            LblFirstName.ForeColor = SystemColors.ControlText;
            LblLastName.ForeColor = SystemColors.ControlText;
            LblPhoneNo.ForeColor = SystemColors.ControlText;
            LblEmail.ForeColor = SystemColors.ControlText;

            TxtFirstName.Text = string.Empty;
            TxtLastName.Text = string.Empty;
            TxtPhoneNo.Text = string.Empty;
            TxtEmail.Text = string.Empty;
        }

        private void ResetButton()
        {
            BtnAdd.Visible = true;
            BtnUpdate.Visible = false;
            BtnDelete.Visible = false;
        }


        #endregion


        #region BUTTON FUNCTIONS

        private void BtnSearch_Click(object sender, EventArgs e)
        {

            DgvCustomer.Rows.Clear();
            ResetForm();
            ResetButton();

            List<Library.Models.Customer> customers = _context.Customers.Where(c => c.FirstName.Contains(TxtFN.Text) && c.PhoneNumber.Contains(TxtSearchPhone.Text)).ToList();

            foreach(var item in customers)
            {
                DgvCustomer.Rows.Add(item.Id,
                                    item.FirstName,
                                    item.LastName,
                                    item.PhoneNumber,
                                    item.Email);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                return;
            }

            var customer = new Library.Models.Customer();

            customer.FirstName = TxtFirstName.Text;
            customer.LastName = TxtLastName.Text;
            customer.PhoneNumber = TxtPhoneNo.Text;
            customer.Email = TxtEmail.Text;


            #region VERIFY THAT DUPLICATE EMAIL ADDRESS IS NOT ENTERED TO THE SYSTEM

            List<Library.Models.Customer> cs = _context.Customers.Where(c => c.Email.Contains(TxtEmail.Text)).ToList();

            foreach(var item in cs)
            {
                if(item.Email == customer.Email)
                {
                    LblEmail.ForeColor = Color.Red;
                    MessageBox.Show("Email address has already been used, please use a different email.", "Attention!");
                    return;
                }
            }

            #endregion



            _context.Customers.Add(customer);
            _context.SaveChanges();



            FillCustomerList();
            ResetForm();

            MessageBox.Show("New Customer is successfully added to the list.", "UPDATE");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are sure to permanently delete the selected customer?", "Delete Customer", MessageBoxButtons.YesNo);

            if(r == DialogResult.Yes)
            {
                _context.Customers.Remove(SelectedCustomer);
                _context.SaveChanges();

                FillCustomerList();
                ResetForm();
                ResetButton();

                MessageBox.Show("Customer is successfully removed from the list.", "Deleted");
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                return;
            }

            SelectedCustomer.FirstName = TxtFirstName.Text;
            SelectedCustomer.LastName = TxtLastName.Text;
            SelectedCustomer.PhoneNumber = TxtPhoneNo.Text;
            SelectedCustomer.Email = TxtEmail.Text;

            _context.SaveChanges();

            FillCustomerList();
            ResetForm();
            ResetButton();

            MessageBox.Show("Selected customer is successfully updated", "UPDATE");
        }

        #endregion


        #region SELECTING CUSTOMERS FROM DGV CUSTOMER LIST
        private void DgvCustomer_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BtnAdd.Visible = false;
            BtnUpdate.Visible = true;
            BtnDelete.Visible = true;


            foreach (var item in _context.Customers.ToList())
            {
                int Id = Convert.ToInt32(DgvCustomer.Rows[e.RowIndex].Cells[0].Value.ToString());

                SelectedCustomer = _context.Customers.Find(Id);


                TxtFirstName.Text = SelectedCustomer.FirstName;
                TxtLastName.Text = SelectedCustomer.LastName;
                TxtPhoneNo.Text = SelectedCustomer.PhoneNumber;
                TxtEmail.Text = SelectedCustomer.Email;
            }
        }

        #endregion

    }
}
