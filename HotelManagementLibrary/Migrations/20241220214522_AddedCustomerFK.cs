using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddedCustomerFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Bookings",
                newName: "customerId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                newName: "IX_Bookings_customerId");

            migrationBuilder.AlterColumn<int>(
                name: "customerId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_customerId",
                table: "Bookings",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_customerId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Bookings",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_customerId",
                table: "Bookings",
                newName: "IX_Bookings_CustomerId");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }
    }
}
