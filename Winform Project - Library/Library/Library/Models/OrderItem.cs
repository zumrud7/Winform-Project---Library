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
    class OrderItem
    {
        public int Id { get; set; }


        [Required]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        [Required]
        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        [Required]
        public int ReturnPeriodId { get; set; }

        public virtual ReturnPeriod ReturnPeriod { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Price { get; set; }


    }
}
