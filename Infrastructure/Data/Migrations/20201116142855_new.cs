using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_orderPlaceds_BookingId",
                table: "orderPlaceds",
                column: "BookingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_orderPlaceds_Bookings_BookingId",
                table: "orderPlaceds",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderPlaceds_Bookings_BookingId",
                table: "orderPlaceds");

            migrationBuilder.DropIndex(
                name: "IX_orderPlaceds_BookingId",
                table: "orderPlaceds");
        }
    }
}
