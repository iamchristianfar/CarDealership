using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealership.DataAccess.Migrations
{
    public partial class ChangesTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "BuyerClientID",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SellerClientID",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

           

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.DropColumn(
                name: "BuyerClientID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SellerClientID",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
