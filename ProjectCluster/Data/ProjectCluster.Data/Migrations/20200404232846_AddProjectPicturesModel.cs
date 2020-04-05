using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCluster.Data.Migrations
{
    public partial class AddProjectPicturesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPicture_Projects_ProjectId",
                table: "ProjectPicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectPicture",
                table: "ProjectPicture");

            migrationBuilder.RenameTable(
                name: "ProjectPicture",
                newName: "ProjectPictures");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectPicture_ProjectId",
                table: "ProjectPictures",
                newName: "IX_ProjectPictures_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectPicture_IsDeleted",
                table: "ProjectPictures",
                newName: "IX_ProjectPictures_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectPictures",
                table: "ProjectPictures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPictures_Projects_ProjectId",
                table: "ProjectPictures",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPictures_Projects_ProjectId",
                table: "ProjectPictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectPictures",
                table: "ProjectPictures");

            migrationBuilder.RenameTable(
                name: "ProjectPictures",
                newName: "ProjectPicture");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectPictures_ProjectId",
                table: "ProjectPicture",
                newName: "IX_ProjectPicture_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectPictures_IsDeleted",
                table: "ProjectPicture",
                newName: "IX_ProjectPicture_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectPicture",
                table: "ProjectPicture",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPicture_Projects_ProjectId",
                table: "ProjectPicture",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
