namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        OrderInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.OrderInfoes", t => t.OrderInfoId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.BookId)
                .Index(t => t.OrderInfoId);
            
            CreateTable(
                "dbo.OrderInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.OrderItems", "OrderInfoId", "dbo.OrderInfoes");
            DropForeignKey("dbo.OrderItems", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderItems", "BookId", "dbo.Books");
            DropIndex("dbo.OrderItems", new[] { "OrderInfoId" });
            DropIndex("dbo.OrderItems", new[] { "BookId" });
            DropIndex("dbo.OrderItems", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "Book_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.OrderInfoes");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Customers");
            DropTable("dbo.Books");
        }
    }
}
