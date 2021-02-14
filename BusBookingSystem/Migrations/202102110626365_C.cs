namespace BusBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class C : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ReservationModels", name: "Id", newName: "UserName");
            RenameColumn(table: "dbo.TransactionModels", name: "Id", newName: "UserName");
            RenameIndex(table: "dbo.ReservationModels", name: "IX_Id", newName: "IX_UserName");
            RenameIndex(table: "dbo.TransactionModels", name: "IX_Id", newName: "IX_UserName");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TransactionModels", name: "IX_UserName", newName: "IX_Id");
            RenameIndex(table: "dbo.ReservationModels", name: "IX_UserName", newName: "IX_Id");
            RenameColumn(table: "dbo.TransactionModels", name: "UserName", newName: "Id");
            RenameColumn(table: "dbo.ReservationModels", name: "UserName", newName: "Id");
        }
    }
}
