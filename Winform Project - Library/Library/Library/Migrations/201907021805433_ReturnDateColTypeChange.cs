namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReturnDateColTypeChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReturnPeriods", "ReturnDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.ReturnPeriods", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReturnPeriods", "Name", c => c.String());
            DropColumn("dbo.ReturnPeriods", "ReturnDate");
        }
    }
}
