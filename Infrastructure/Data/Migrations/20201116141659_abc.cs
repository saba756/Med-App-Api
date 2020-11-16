using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleiverd",
                table: "orderPlaceds");

            migrationBuilder.AddColumn<bool>(
                name: "isDelivered",
                table: "orderPlaceds",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CarrierId",
                table: "Bookings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_OrderPlacedId",
                table: "Reviews",
                column: "OrderPlacedId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_orderPlaceds_OrderPlacedId",
                table: "Reviews",
                column: "OrderPlacedId",
                principalTable: "orderPlaceds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Carriers_CarrierId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_orderPlaceds_OrderPlacedId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_OrderPlacedId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CarrierId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "isDelivered",
                table: "orderPlaceds");

            migrationBuilder.DropColumn(
                name: "CarrierId",
                table: "Bookings");

            migrationBuilder.AddColumn<bool>(
                name: "isDeleiverd",
                table: "orderPlaceds",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
