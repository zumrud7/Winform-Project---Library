namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Book_Id", "dbo.Books");
            DropIndex("dbo.Customers", new[] { "Book_Id" });
            DropColumn("dbo.Customers", "Book_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Book_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Book_Id");
            AddForeignKey("dbo.Customers", "Book_Id", "dbo.Books", "Id");
        }
    }
}
