namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.ReserveId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.BusModels", t => t.BusId)
                .Index(t => t.Id)
                .Index(t => t.BusId);
            
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
                .PrimaryKey(t => t.TranscationId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.ReservationModels", t => t.ReserveId)
                .Index(t => t.Id)
                .Index(t => t.ReserveId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionModels", "ReserveId", "dbo.ReservationModels");
            DropForeignKey("dbo.TransactionModels", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReservationModels", "BusId", "dbo.BusModels");
            DropForeignKey("dbo.ReservationModels", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.TransactionModels", new[] { "ReserveId" });
            DropIndex("dbo.TransactionModels", new[] { "Id" });
            DropIndex("dbo.ReservationModels", new[] { "BusId" });
            DropIndex("dbo.ReservationModels", new[] { "Id" });
            DropTable("dbo.TransactionModels");
            DropTable("dbo.ReservationModels");
        }
    }
}
