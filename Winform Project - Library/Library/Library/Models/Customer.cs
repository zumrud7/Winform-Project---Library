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
    class Customer
    {
        public Customer()
        {
            orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, RegularExpression(@"^\+994 (50|55|51|70|77) \d{3} \d{2} \d{2}$")]
       
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<Order> orders { get; set; }

    }
}
