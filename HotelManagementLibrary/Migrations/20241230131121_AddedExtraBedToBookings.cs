using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddedExtraBedToBookings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "extraBed",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "extraBed",
                table: "Bookings");
        }
    }
}
