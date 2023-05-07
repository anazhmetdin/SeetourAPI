using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeetourAPI.Migrations
{
    /// <inheritdoc />
    public partial class views : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "ExpirationDate",
                table: "payments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AddPrimaryKey(
                name: "PK_payments",
                table: "payments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Views",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViewsNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Views", x => x.Id);
                });

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

            migrationBuilder.DropTable(
                name: "Views");

            migrationBuilder.DropPrimaryKey(
                name: "PK_payments",
                table: "payments");

            migrationBuilder.RenameTable(
                name: "payments",
                newName: "TourBookingPayment");

            migrationBuilder.AlterColumn<string>(
                name: "ExpirationDate",
                table: "TourBookingPayment",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

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
