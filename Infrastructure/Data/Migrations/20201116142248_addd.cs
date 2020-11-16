using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class addd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Carriers_CarrierId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CarrierId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CarrierId",
                table: "Bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarrierId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CarrierId",
                table: "Bookings",
                column: "CarrierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Carriers_CarrierId",
                table: "Bookings",
                column: "CarrierId",
                principalTable: "Carriers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
