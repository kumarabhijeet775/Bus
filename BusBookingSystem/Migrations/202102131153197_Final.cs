namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TransactionModels", "ReserveId", "dbo.ReservationModels");
            DropIndex("dbo.TransactionModels", new[] { "ReserveId" });
            AddColumn("dbo.TransactionModels", "BusId", c => c.Int());
            CreateIndex("dbo.TransactionModels", "BusId");
            AddForeignKey("dbo.TransactionModels", "BusId", "dbo.BusModels", "BusId");
            DropColumn("dbo.TransactionModels", "ReserveId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransactionModels", "ReserveId", c => c.Int());
            DropForeignKey("dbo.TransactionModels", "BusId", "dbo.BusModels");
            DropIndex("dbo.TransactionModels", new[] { "BusId" });
            DropColumn("dbo.TransactionModels", "BusId");
            CreateIndex("dbo.TransactionModels", "ReserveId");
            AddForeignKey("dbo.TransactionModels", "ReserveId", "dbo.ReservationModels", "ReserveId");
        }
    }
}
