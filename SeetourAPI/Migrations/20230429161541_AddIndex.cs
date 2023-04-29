using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeetourAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BookedTours_ReviewId",
                table: "BookedTours",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_BookedTours_Status",
                table: "BookedTours",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookedTours_ReviewId",
                table: "BookedTours");

            migrationBuilder.DropIndex(
                name: "IX_BookedTours_Status",
                table: "BookedTours");
        }
    }
}
