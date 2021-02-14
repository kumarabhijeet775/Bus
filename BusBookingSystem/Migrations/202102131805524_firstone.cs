namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TransactionModels", "TransactionType", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TransactionModels", "TransactionType", c => c.String(nullable: false));
        }
    }
}
