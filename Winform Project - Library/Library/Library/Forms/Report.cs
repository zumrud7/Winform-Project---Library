using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Library.DAL;
using Library.Models;
using System.IO;
using System.Reflection;
using ClosedXML.Excel;

namespace Library.Forms
{
    public partial class Report : Form
    {
        private readonly LibraryContext _context;
        public Report()
        {
            InitializeComponent();

            _context = new LibraryContext();

            this.BindData();
        }



        //private void FillOrderList()
        //{
        //    DgvOrderList.Columns[1].DefaultCellStyle.Format = "dd-MM-yyyy";
        //    DgvOrderList.Columns[5].DefaultCellStyle.Format = "dd-MM-yyyy";

        //    DgvOrderList.Rows.Clear();

        //    List<OrderItem> orders = _context.OrderItems.Include("Book").Include("Order").Include("Order.Customer").Where(o => o.Order.CreatedOn >= DateFrom.Value && o.Order.CreatedOn <= DateTo.Value).ToList();

        //    foreach (var item in orders)
        //    {
        //        DgvOrderList.Rows.Add(item.Id,
        //                                item.Order.CreatedOn,
        //                                item.Order.Customer.FirstName + " " + item.Order.Customer.LastName,
        //                                item.Book.Name,
        //                                item.Count,
        //                                item.ReturnDate,
        //                                item.Price);



        //    }


        //}

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //FillOrderList();

        }


        private void BtnExport_Click(object sender, EventArgs e)
        {

            

            DataTable dt = new DataTable();


            foreach (DataGridViewColumn column in DgvOrderList.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            foreach (DataGridViewRow row in DgvOrderList.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }

            string folderPath = "C:\\Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "OrderList");
                wb.SaveAs(folderPath + "DgvOrderListExport.xlsx");
            }



        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void BindData()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("Id", typeof(int)),
            new DataColumn("Create Date", typeof(DateTime)),
            new DataColumn("Customer Name",typeof(string)),
            new DataColumn("Book", typeof(string)),
            new DataColumn("Count", typeof(int)),
            new DataColumn("Return Date", typeof(DateTime)),
            new DataColumn("Price", typeof(decimal))});
            

            this.DgvOrderList.DataSource = dt;
        }


    }
}
