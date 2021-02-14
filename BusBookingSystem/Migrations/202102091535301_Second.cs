namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReservationModels", "PasId", "dbo.PassengerModels");
            DropForeignKey("dbo.TransactionModels", "PasId", "dbo.PassengerModels");
            DropIndex("dbo.ReservationModels", new[] { "PasId" });
            DropIndex("dbo.TransactionModels", new[] { "PasId" });
            AddColumn("dbo.ReservationModels", "Id", c => c.String(maxLength: 128));
            AddColumn("dbo.TransactionModels", "Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "PasWallet", c => c.Int(nullable: false));
            CreateIndex("dbo.ReservationModels", "Id");
            CreateIndex("dbo.TransactionModels", "Id");
            AddForeignKey("dbo.ReservationModels", "Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TransactionModels", "Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.ReservationModels", "PasId");
            DropColumn("dbo.TransactionModels", "PasId");
            DropTable("dbo.PassengerModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PassengerModels",
                c => new
                    {
                        PasId = c.Int(nullable: false, identity: true),
                        PasPassword = c.String(nullable: false, maxLength: 30),
                        PasName = c.String(nullable: false, maxLength: 50),
                        PasPhoneNo = c.String(nullable: false, maxLength: 10),
                        PasEmail = c.String(nullable: false, maxLength: 50),
                        PasWallet = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PasId);
            
            AddColumn("dbo.TransactionModels", "PasId", c => c.Int());
            AddColumn("dbo.ReservationModels", "PasId", c => c.Int());
            DropForeignKey("dbo.TransactionModels", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReservationModels", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.TransactionModels", new[] { "Id" });
            DropIndex("dbo.ReservationModels", new[] { "Id" });
            DropColumn("dbo.AspNetUsers", "PasWallet");
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.TransactionModels", "Id");
            DropColumn("dbo.ReservationModels", "Id");
            CreateIndex("dbo.TransactionModels", "PasId");
            CreateIndex("dbo.ReservationModels", "PasId");
            AddForeignKey("dbo.TransactionModels", "PasId", "dbo.PassengerModels", "PasId");
            AddForeignKey("dbo.ReservationModels", "PasId", "dbo.PassengerModels", "PasId");
        }
    }
}
