using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealership.DataAccess.Migrations
{
    public partial class FKUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyRepresentativeID",
                table: "Clients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CompanyRepresentativeID",
                table: "Clients",
                column: "CompanyRepresentativeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_CompanyRepresentative_CompanyRepresentativeID",
                table: "Clients",
                column: "CompanyRepresentativeID",
                principalTable: "CompanyRepresentative",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_CompanyRepresentative_CompanyRepresentativeID",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CompanyRepresentativeID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CompanyRepresentativeID",
                table: "Clients");
        }
    }
}
