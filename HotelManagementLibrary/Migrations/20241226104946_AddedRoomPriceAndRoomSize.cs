using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddedRoomPriceAndRoomSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "RoomPrice",
                table: "Rooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "RoomSize",
                table: "Rooms",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomPrice",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomSize",
                table: "Rooms");
        }
    }
}
