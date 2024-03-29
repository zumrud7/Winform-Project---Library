﻿namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveReguiredPrice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderItems", "Price", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Books", "Price", c => c.Decimal(nullable: false, storeType: "money"));
        }
    }
}
