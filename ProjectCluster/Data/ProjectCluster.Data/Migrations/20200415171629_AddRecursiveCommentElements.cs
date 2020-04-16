using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCluster.Data.Migrations
{
    public partial class AddRecursiveCommentElements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "ParrentId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParrentId",
                table: "Comments",
                column: "ParrentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParrentId",
                table: "Comments",
                column: "ParrentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParrentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ParrentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ParrentId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
