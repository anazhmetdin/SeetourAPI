using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeetourAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddIsCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EditRequest_Tours_TourId",
                table: "EditRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EditRequest",
                table: "EditRequest");

            migrationBuilder.RenameTable(
                name: "EditRequest",
                newName: "EditRequests");

            migrationBuilder.RenameIndex(
                name: "IX_EditRequest_TourId",
                table: "EditRequests",
                newName: "IX_EditRequests_TourId");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "TourBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EditRequests",
                table: "EditRequests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EditRequests_Tours_TourId",
                table: "EditRequests",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EditRequests_Tours_TourId",
                table: "EditRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EditRequests",
                table: "EditRequests");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "TourBookings");

            migrationBuilder.RenameTable(
                name: "EditRequests",
                newName: "EditRequest");

            migrationBuilder.RenameIndex(
                name: "IX_EditRequests_TourId",
                table: "EditRequest",
                newName: "IX_EditRequest_TourId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EditRequest",
                table: "EditRequest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EditRequest_Tours_TourId",
                table: "EditRequest",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
