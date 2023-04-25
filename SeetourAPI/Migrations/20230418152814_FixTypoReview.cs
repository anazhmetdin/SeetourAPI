using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeetourAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixTypoReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_BookedTours_BoodedTourId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "BoodedTourId",
                table: "Reviews",
                newName: "BookedTourId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BoodedTourId",
                table: "Reviews",
                newName: "IX_Reviews_BookedTourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_BookedTours_BookedTourId",
                table: "Reviews",
                column: "BookedTourId",
                principalTable: "BookedTours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_BookedTours_BookedTourId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "BookedTourId",
                table: "Reviews",
                newName: "BoodedTourId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BookedTourId",
                table: "Reviews",
                newName: "IX_Reviews_BoodedTourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_BookedTours_BoodedTourId",
                table: "Reviews",
                column: "BoodedTourId",
                principalTable: "BookedTours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
