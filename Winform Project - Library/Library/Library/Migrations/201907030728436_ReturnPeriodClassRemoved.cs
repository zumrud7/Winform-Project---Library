namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReturnPeriodClassRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "ReturnPeriodId", "dbo.ReturnPeriods");
            DropIndex("dbo.OrderItems", new[] { "ReturnPeriodId" });
            AddColumn("dbo.OrderItems", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderItems", "ReturnDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.OrderItems", "ReturnPeriodId");
            DropColumn("dbo.OrderItems", "Date");
            DropTable("dbo.ReturnPeriods");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReturnPeriods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReturnDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.OrderItems", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderItems", "ReturnPeriodId", c => c.Int(nullable: false));
            DropColumn("dbo.OrderItems", "ReturnDate");
            DropColumn("dbo.OrderItems", "CreateDate");
            CreateIndex("dbo.OrderItems", "ReturnPeriodId");
            AddForeignKey("dbo.OrderItems", "ReturnPeriodId", "dbo.ReturnPeriods", "Id", cascadeDelete: true);
        }
    }
}
