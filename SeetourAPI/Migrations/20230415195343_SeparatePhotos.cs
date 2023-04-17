using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeetourAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeparatePhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTours_TourBookingPayment_TourBookingPaymentId",
                table: "BookedTours");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Reviews_ReviewId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Tours_TourId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_TourQuestions_TourAnswer_TourAnswerId",
                table: "TourQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TourQuestions_TourAnswerId",
                table: "TourQuestions");

            migrationBuilder.DropIndex(
                name: "IX_Photos_ReviewId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_TourId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_BookedTours_TourBookingPaymentId",
                table: "BookedTours");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "Photos");

            migrationBuilder.AlterColumn<string>(
                name: "ExpirationDate",
                table: "TourBookingPayment",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)");

            migrationBuilder.AlterColumn<string>(
                name: "Cvc",
                table: "TourBookingPayment",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(3)");

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "TourBookingPayment",
                type: "nvarchar(19)",
                maxLength: 19,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(19)");

            migrationBuilder.AlterColumn<int>(
                name: "TourBookingPaymentId",
                table: "BookedTours",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ReviewPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoId = table.Column<int>(type: "int", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewPhoto_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewPhoto_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoId = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourPhoto_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourPhoto_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourAnswer_TourQuestionId",
                table: "TourAnswer",
                column: "TourQuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookedTours_TourBookingPaymentId",
                table: "BookedTours",
                column: "TourBookingPaymentId",
                unique: true,
                filter: "[TourBookingPaymentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewPhoto_PhotoId",
                table: "ReviewPhoto",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewPhoto_ReviewId",
                table: "ReviewPhoto",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_TourPhoto_PhotoId",
                table: "TourPhoto",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_TourPhoto_TourId",
                table: "TourPhoto",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTours_TourBookingPayment_TourBookingPaymentId",
                table: "BookedTours",
                column: "TourBookingPaymentId",
                principalTable: "TourBookingPayment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TourAnswer_TourQuestions_TourQuestionId",
                table: "TourAnswer",
                column: "TourQuestionId",
                principalTable: "TourQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTours_TourBookingPayment_TourBookingPaymentId",
                table: "BookedTours");

            migrationBuilder.DropForeignKey(
                name: "FK_TourAnswer_TourQuestions_TourQuestionId",
                table: "TourAnswer");

            migrationBuilder.DropTable(
                name: "ReviewPhoto");

            migrationBuilder.DropTable(
                name: "TourPhoto");

            migrationBuilder.DropIndex(
                name: "IX_TourAnswer_TourQuestionId",
                table: "TourAnswer");

            migrationBuilder.DropIndex(
                name: "IX_BookedTours_TourBookingPaymentId",
                table: "BookedTours");

            migrationBuilder.AlterColumn<string>(
                name: "ExpirationDate",
                table: "TourBookingPayment",
                type: "varchar(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Cvc",
                table: "TourBookingPayment",
                type: "varchar(3)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "TourBookingPayment",
                type: "varchar(19)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(19)",
                oldMaxLength: 19);

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TourId",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TourBookingPaymentId",
                table: "BookedTours",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TourQuestions_TourAnswerId",
                table: "TourQuestions",
                column: "TourAnswerId",
                unique: true,
                filter: "[TourAnswerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ReviewId",
                table: "Photos",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_TourId",
                table: "Photos",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_BookedTours_TourBookingPaymentId",
                table: "BookedTours",
                column: "TourBookingPaymentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTours_TourBookingPayment_TourBookingPaymentId",
                table: "BookedTours",
                column: "TourBookingPaymentId",
                principalTable: "TourBookingPayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Reviews_ReviewId",
                table: "Photos",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Tours_TourId",
                table: "Photos",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TourQuestions_TourAnswer_TourAnswerId",
                table: "TourQuestions",
                column: "TourAnswerId",
                principalTable: "TourAnswer",
                principalColumn: "Id");
        }
    }
}
