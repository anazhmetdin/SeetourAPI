using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeetourAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTourGuideRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TourGuideRatings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    RatingCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourGuideRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourGuideRatings_TourGuides_Id",
                        column: x => x.Id,
                        principalTable: "TourGuides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourGuideRatings");
        }
    }
}
