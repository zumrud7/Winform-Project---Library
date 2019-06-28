namespace Library.Migrations
{
    using Library.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library.DAL.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Library.DAL.LibraryContext context)
        {
            Book bk1 = new Book
            {
                Name = "Brida",
                Count = 3,
                Price = 5
            };

            context.Books.Add(bk1);
            context.SaveChanges();

            Book bk2 = new Book
            {
                Name = "Acra",
                Count = 5,
                Price = 7
            };

            context.Books.Add(bk2);
            context.SaveChanges();

            Book bk3 = new Book
            {
                Name = "Book of Joy",
                Count = 1,
                Price = 12
            };

            context.Books.Add(bk3);
            context.SaveChanges();

            User user1 = new User
            {
                FirstName = "Zumrud",
                LastName = "Aliyeva",
                UserName = "Zumi",
                Password = "qwerty"
            };

            context.Users.Add(user1);
            context.SaveChanges();

            User user2 = new User
            {
                FirstName = "Guitara",
                LastName = "Kina",
                UserName = "GK",
                Password = "qwerty123"
            };

            context.Users.Add(user2);
            context.SaveChanges();

            Customer cst1 = new Customer
            {
                FirstName = "Zeinab",
                LastName = "Salimbayli",
                PhoneNumber = "+994 50 225 02 20",
                Email = "bouncy_z@hotmail.com"
            };

            context.Customers.Add(cst1);
            context.SaveChanges();

            Customer cst2 = new Customer
            {
                FirstName = "Salim",
                LastName = "Salimbayli",
                PhoneNumber = "+994 55 234 44 33",
                Email = "salim@gmail.com"
            };

            context.Customers.Add(cst2);
            context.SaveChanges();


            OrderInfo orderinfo1 = new OrderInfo
            {
                Count = 1,
                Price = 12
            };

            context.OrderInfos.Add(orderinfo1);
            context.SaveChanges();

            OrderInfo orderinfo2 = new OrderInfo
            {
                Count = 1,
                Price = 7
            };

            context.OrderInfos.Add(orderinfo2);
            context.SaveChanges();

            OrderItem order1 = new OrderItem
            {
                CustomerId = cst1.Id,
                BookId = bk2.Id,
                Date = DateTime.Now.AddDays(-5),
                OrderInfoId = orderinfo2.Id

            };

            context.OrderItems.Add(order1);
            context.SaveChanges();

            OrderItem order2 = new OrderItem
            {
                CustomerId = cst2.Id,
                BookId = bk3.Id,
                Date = DateTime.Now.AddDays(-1),
                OrderInfoId = orderinfo1.Id
            };

            context.OrderItems.Add(order2);
            context.SaveChanges();

        }
    }
}
