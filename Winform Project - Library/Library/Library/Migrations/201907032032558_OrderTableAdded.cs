namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderTableAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "CustomerId", "dbo.Customers");
            DropIndex("dbo.OrderItems", new[] { "CustomerId" });
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            AddColumn("dbo.OrderItems", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "OrderId");
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            DropColumn("dbo.OrderItems", "CustomerId");
            DropColumn("dbo.OrderItems", "CreateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderItems", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropColumn("dbo.OrderItems", "OrderId");
            DropTable("dbo.Orders");
            CreateIndex("dbo.OrderItems", "CustomerId");
            AddForeignKey("dbo.OrderItems", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
