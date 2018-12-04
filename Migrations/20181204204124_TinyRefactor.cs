using Microsoft.EntityFrameworkCore.Migrations;

namespace Persons.Migrations
{
    public partial class TinyRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Opinions_OpinionId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "information",
                table: "Opinions",
                newName: "Information");

            migrationBuilder.AlterColumn<int>(
                name: "OpinionId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Opinions_OpinionId",
                table: "Comments",
                column: "OpinionId",
                principalTable: "Opinions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Opinions_OpinionId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Information",
                table: "Opinions",
                newName: "information");

            migrationBuilder.AlterColumn<int>(
                name: "OpinionId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Opinions_OpinionId",
                table: "Comments",
                column: "OpinionId",
                principalTable: "Opinions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
