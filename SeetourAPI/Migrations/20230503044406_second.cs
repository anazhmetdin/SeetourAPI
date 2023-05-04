using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeetourAPI.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTours_TourBookingPayment_TourBookingPaymentId",
                table: "BookedTours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourBookingPayment",
                table: "TourBookingPayment");

            migrationBuilder.RenameTable(
                name: "TourBookingPayment",
                newName: "payments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_payments",
                table: "payments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTours_payments_TourBookingPaymentId",
                table: "BookedTours",
                column: "TourBookingPaymentId",
                principalTable: "payments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTours_payments_TourBookingPaymentId",
                table: "BookedTours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_payments",
                table: "payments");

            migrationBuilder.RenameTable(
                name: "payments",
                newName: "TourBookingPayment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourBookingPayment",
                table: "TourBookingPayment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTours_TourBookingPayment_TourBookingPaymentId",
                table: "BookedTours",
                column: "TourBookingPaymentId",
                principalTable: "TourBookingPayment",
                principalColumn: "Id");
        }
    }
}
