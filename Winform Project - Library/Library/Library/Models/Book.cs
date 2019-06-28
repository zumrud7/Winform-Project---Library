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
    class Book
    {
        public Book()
        {
            customers = new HashSet<Customer>();

            orderitems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }

        public ICollection<Customer> customers { get; set; }

        public ICollection<OrderItem> orderitems { get; set; }
    }
}
