namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderInfoTableDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "OrderInfoId", "dbo.OrderInfoes");
            DropIndex("dbo.OrderItems", new[] { "OrderInfoId" });
            AddColumn("dbo.OrderItems", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.OrderItems", "Price", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.OrderItems", "OrderInfoId");
            DropTable("dbo.OrderInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.OrderItems", "OrderInfoId", c => c.Int(nullable: false));
            DropColumn("dbo.OrderItems", "Price");
            DropColumn("dbo.OrderItems", "Count");
            CreateIndex("dbo.OrderItems", "OrderInfoId");
            AddForeignKey("dbo.OrderItems", "OrderInfoId", "dbo.OrderInfoes", "Id", cascadeDelete: true);
        }
    }
}
