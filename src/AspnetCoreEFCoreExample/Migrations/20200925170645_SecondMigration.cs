using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AspnetCoreEFCoreExample.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Element_User_UserId",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_UserId",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Element");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Element",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Element_UserId",
                table: "Element",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Element_User_UserId",
                table: "Element",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
