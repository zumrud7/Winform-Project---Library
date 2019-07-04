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
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.BringToFront();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel2.BringToFront();
        }
    }
}
