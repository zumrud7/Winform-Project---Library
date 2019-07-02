using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL;
using Library.Forms;

namespace Library.Models
{
    class ComboboxDate
    {
        public string Name  { get; set; }

        public DateTime Date { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
