using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementLibrary.Migrations
{
    /// <inheritdoc />
    public partial class RemovedInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Invoices_InvoiceId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_InvoiceId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Bookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_InvoiceId",
                table: "Bookings",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Invoices_InvoiceId",
                table: "Bookings",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
