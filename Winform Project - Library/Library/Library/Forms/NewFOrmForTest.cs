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
    public partial class NewFOrmForTest : Form
    {
        public NewFOrmForTest()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            //panel1.BringToFront();
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            //panel2.BringToFront();
            panel1.Visible = false;
            panel3.Visible = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            //panel1.BringToFront();
            panel2.Visible = false;
            panel1.Visible = false;
        }
    }
}
