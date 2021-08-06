using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealership.DataAccess.Migrations
{
    public partial class NewSectionCarService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ServiceIn",
                table: "CarService",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ServiceOut",
                table: "CarService",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceIn",
                table: "CarService");

            migrationBuilder.DropColumn(
                name: "ServiceOut",
                table: "CarService");
        }
    }
}
