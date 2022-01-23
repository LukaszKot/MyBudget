using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBudget.App.Migrations
{
    public partial class AddedUserIdToOperationCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "OperationCategories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OperationCategories_UserId",
                table: "OperationCategories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationCategories_Users_UserId",
                table: "OperationCategories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationCategories_Users_UserId",
                table: "OperationCategories");

            migrationBuilder.DropIndex(
                name: "IX_OperationCategories_UserId",
                table: "OperationCategories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OperationCategories");
        }
    }
}
