using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Library.Models;


namespace Library.DAL
{
    class LibraryContext: DbContext
    {
       public LibraryContext(): base("LibraryContext")
        {

        }


        public DbSet<Book> Books { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<OrderInfo> OrderInfos { get; set; }
    }
}
