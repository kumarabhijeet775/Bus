namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Converse : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ReservationModels", name: "UserName", newName: "Id");
            RenameColumn(table: "dbo.TransactionModels", name: "UserName", newName: "Id");
            RenameIndex(table: "dbo.ReservationModels", name: "IX_UserName", newName: "IX_Id");
            RenameIndex(table: "dbo.TransactionModels", name: "IX_UserName", newName: "IX_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TransactionModels", name: "IX_Id", newName: "IX_UserName");
            RenameIndex(table: "dbo.ReservationModels", name: "IX_Id", newName: "IX_UserName");
            RenameColumn(table: "dbo.TransactionModels", name: "Id", newName: "UserName");
            RenameColumn(table: "dbo.ReservationModels", name: "Id", newName: "UserName");
        }
    }
}
