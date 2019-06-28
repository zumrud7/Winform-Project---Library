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

        private void Btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
