using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    class Order
    {
        public Order()
        {
            orderitems = new HashSet<OrderItem>();
        }
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public decimal TotalPrice { get; set; }

        public ICollection<OrderItem> orderitems { get; set; }
    }
}
