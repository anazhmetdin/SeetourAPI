using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeetourAPI.Migrations
{
    /// <inheritdoc />
    public partial class addsecurityLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourAnswer_TourQuestions_TourQuestionId",
                table: "TourAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourAnswer",
                table: "TourAnswer");

            migrationBuilder.RenameTable(
                name: "TourAnswer",
                newName: "TourAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_TourAnswer_TourQuestionId",
                table: "TourAnswers",
                newName: "IX_TourAnswers_TourQuestionId");

            migrationBuilder.AddColumn<string>(
                name: "IDCardPhoto",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecurityLevel",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourAnswers",
                table: "TourAnswers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TourAnswers_TourQuestions_TourQuestionId",
                table: "TourAnswers",
                column: "TourQuestionId",
                principalTable: "TourQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourAnswers_TourQuestions_TourQuestionId",
                table: "TourAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourAnswers",
                table: "TourAnswers");

            migrationBuilder.DropColumn(
                name: "IDCardPhoto",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecurityLevel",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "TourAnswers",
                newName: "TourAnswer");

            migrationBuilder.RenameIndex(
                name: "IX_TourAnswers_TourQuestionId",
                table: "TourAnswer",
                newName: "IX_TourAnswer_TourQuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourAnswer",
                table: "TourAnswer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TourAnswer_TourQuestions_TourQuestionId",
                table: "TourAnswer",
                column: "TourQuestionId",
                principalTable: "TourQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
