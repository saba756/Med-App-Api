using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone_No",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Customers",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PharmacyId",
                table: "Bookings",
                column: "PharmacyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Pharmacies_PharmacyId",
                table: "Bookings",
                column: "PharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Pharmacies_PharmacyId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PharmacyId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Customers",
                newName: "userName");

            migrationBuilder.AddColumn<string>(
                name: "Phone_No",
                table: "Customers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
