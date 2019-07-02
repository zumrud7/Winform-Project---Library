using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL;

namespace Library.Models
{
    class ReturnPeriod
    {

        public ReturnPeriod()
        {
            orderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }

        public DateTime ReturnDate { get; set; }

        public ICollection<OrderItem> orderItems { get; set; }
    }
}
