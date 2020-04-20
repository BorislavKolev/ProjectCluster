﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCluster.Data.Migrations
{
    public partial class EditParentColumnNameInCommentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ParentId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentId",
                table: "Comments",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentId",
                table: "Comments",
                column: "ParentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ParentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "ParrentId",
                table: "Comments",
                type: "int",
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
    }
}