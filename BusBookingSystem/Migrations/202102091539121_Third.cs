namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Wallet", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "PasWallet");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "PasWallet", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Wallet");
        }
    }
}
