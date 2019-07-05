namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsCompletedColumnAddedToOrderItemTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "isCompleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderItems", "isCompleted");
        }
    }
}
