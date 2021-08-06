using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealership.DataAccess.Migrations
{
    public partial class NewName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarType",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "CarModel",
                table: "Cars",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarModel",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "CarType",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
