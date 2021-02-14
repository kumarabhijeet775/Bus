namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Abcd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReservationModels", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReservationModels", "BusId", "dbo.BusModels");
            DropForeignKey("dbo.TransactionModels", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TransactionModels", "ReserveId", "dbo.ReservationModels");
            DropIndex("dbo.ReservationModels", new[] { "Id" });
            DropIndex("dbo.ReservationModels", new[] { "BusId" });
            DropIndex("dbo.TransactionModels", new[] { "Id" });
            DropIndex("dbo.TransactionModels", new[] { "ReserveId" });
            DropTable("dbo.ReservationModels");
            DropTable("dbo.TransactionModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TransactionModels",
                c => new
                    {
                        TranscationId = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(nullable: false, maxLength: 16),
                        ExpiryDate = c.String(nullable: false, maxLength: 5),
                        Cvv = c.Int(nullable: false),
                        TransactionType = c.String(nullable: false),
                        Id = c.String(maxLength: 128),
                        ReserveId = c.Int(),
                    })
                .PrimaryKey(t => t.TranscationId);
            
            CreateTable(
                "dbo.ReservationModels",
                c => new
                    {
                        ReserveId = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        BusId = c.Int(),
                        NoOfSeats = c.Int(nullable: false),
                        TotalAmount = c.Int(nullable: false),
                        DateOfTravel = c.DateTime(nullable: false),
                        DateOfBooking = c.DateTime(nullable: false),
                        BoardingPoint = c.String(nullable: false),
                        DestinationPoint = c.String(nullable: false),
                        BusType = c.String(nullable: false),
                        SeatNumber = c.String(),
                        SeatType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ReserveId);
            
            CreateIndex("dbo.TransactionModels", "ReserveId");
            CreateIndex("dbo.TransactionModels", "Id");
            CreateIndex("dbo.ReservationModels", "BusId");
            CreateIndex("dbo.ReservationModels", "Id");
            AddForeignKey("dbo.TransactionModels", "ReserveId", "dbo.ReservationModels", "ReserveId");
            AddForeignKey("dbo.TransactionModels", "Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ReservationModels", "BusId", "dbo.BusModels", "BusId");
            AddForeignKey("dbo.ReservationModels", "Id", "dbo.AspNetUsers", "Id");
        }
    }
}
