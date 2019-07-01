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
    public partial class Book : Form
    {

        private readonly LibraryContext _context;

        private Library.Models.Book SelectedBook;
        public Book()
        {
            InitializeComponent();

            _context = new LibraryContext();

            FillBookList();
        }

        #region Fill Dgv with book list
        private void FillBookList()
        {
            DgvBook.Rows.Clear();

            foreach (var item in _context.Books.ToList())
            {
                DgvBook.Rows.Add(item.Id,
                                 item.Name,
                                 item.Price,
                                 item.Count);
            }
        }

        #endregion


        #region Methods
        private bool Validation()
        {
            if (string.IsNullOrEmpty(TxtName.Text))
            {
                LblName.ForeColor = Color.Red;
                LblPrice.ForeColor = SystemColors.ControlText;
                LblCount.ForeColor = SystemColors.ControlText;

                return false;
            }
            if (string.IsNullOrEmpty(TxtPrice.Text))
            {
                LblName.ForeColor = SystemColors.ControlText;
                LblPrice.ForeColor = Color.Red;
                LblCount.ForeColor = SystemColors.ControlText;

                return false;
            }
            if (NumCount.Text == "0")
            {
                LblName.ForeColor = SystemColors.ControlText;
                LblPrice.ForeColor = SystemColors.ControlText;
                LblCount.ForeColor = Color.Red;

                return false;
            }

            return true;

        }

        private void ResetForm()
        {
            TxtName.Text = string.Empty;
            TxtPrice.Text = string.Empty;
            NumCount.Text = "0";

            LblName.ForeColor = SystemColors.ControlText;
            LblPrice.ForeColor = SystemColors.ControlText;
            LblCount.ForeColor = SystemColors.ControlText;
        }

        private void ButtonReset()
        {
            BtnAdd.Visible = true;
            BtnDelete.Visible = false;
            BtnUpdate.Visible = false;
        }

        #endregion


        #region Button Functions
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                return;
            }

            Library.Models.Book book = new Library.Models.Book();

            book.Name = TxtName.Text;
            book.Price = Convert.ToInt32(TxtPrice.Text);
            book.Count = Convert.ToInt32(NumCount.Text);


            #region Verifying that duplicate book name is not entered in the system

            List<Library.Models.Book> bk = _context.Books.Where(b => b.Name.Contains(TxtName.Text)).ToList();

            foreach(var item in bk)
            {
                if(item.Name == book.Name)
                {
                    LblName.ForeColor = Color.Red;
                    MessageBox.Show("Entered book name already exists in the library.", "Attention");
                    ResetForm();
                    return;
                }
            }
            #endregion


            _context.Books.Add(book);
            _context.SaveChanges();

            FillBookList();
            ResetForm();

            MessageBox.Show("New Book is successfully added to the list.", "UPDATE");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure to permanently delete the selected book?", "Delete Book", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                _context.Books.Remove(SelectedBook);

                _context.SaveChanges();


                FillBookList();
                ResetForm();
                ButtonReset();

                MessageBox.Show("Book is successfully removed from the list.", "Deleted");
            }

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                return;
            }

            SelectedBook.Name = TxtName.Text;
            SelectedBook.Price = Convert.ToDecimal(TxtPrice.Text);
            SelectedBook.Count = Convert.ToInt32(NumCount.Text);

            _context.SaveChanges();

            FillBookList();
            ResetForm();
            ButtonReset();

            MessageBox.Show("Selected book is successfully updated", "UPDATE");
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
           
            ResetForm();
            ButtonReset();
            DgvBook.Rows.Clear();


            List<Library.Models.Book> books = _context.Books.Where(b => b.Name.Contains(TxtSearchName.Text)).ToList();

            foreach(var item in books)
            {
                DgvBook.Rows.Add(item.Id,
                                    item.Name,
                                    item.Price,
                                    item.Count);
            }

            
        }

        #endregion


        #region Select books from DGV Book List
        private void DgvBook_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BtnAdd.Visible = false;
            BtnDelete.Visible = true;
            BtnUpdate.Visible = true;

            ResetForm();

            foreach (var item in _context.Books.ToList())
            {

                int Id = Convert.ToInt32(DgvBook.Rows[e.RowIndex].Cells[0].Value.ToString());

                SelectedBook = _context.Books.Find(Id);

                TxtName.Text = SelectedBook.Name;
                TxtPrice.Text = SelectedBook.Price.ToString();
                NumCount.Value = SelectedBook.Count;

            }

        }
        #endregion

    }

}
