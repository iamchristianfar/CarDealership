using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealership.DataAccess.Migrations
{
    public partial class ChangedToSingular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Clients_ClientsID",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ClientsID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarsID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ClientsID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ClientsID",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarID",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ClientID",
                table: "Cars",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Clients_ClientID",
                table: "Cars",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Clients_ClientID",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ClientID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarsID",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientsID",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientsID",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ClientsID",
                table: "Cars",
                column: "ClientsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Clients_ClientsID",
                table: "Cars",
                column: "ClientsID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
