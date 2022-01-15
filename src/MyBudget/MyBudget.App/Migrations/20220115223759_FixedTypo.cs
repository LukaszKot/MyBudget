using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBudget.App.Migrations
{
    public partial class FixedTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_OperationCategories_OperationCategoryId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_OperationCategoryId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "OperaionCategoryId",
                table: "OperationTemplates");

            migrationBuilder.DropColumn(
                name: "OperationCategoryId",
                table: "Operations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OperaionCategoryId",
                table: "OperationTemplates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OperationCategoryId",
                table: "Operations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operations_OperationCategoryId",
                table: "Operations",
                column: "OperationCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_OperationCategories_OperationCategoryId",
                table: "Operations",
                column: "OperationCategoryId",
                principalTable: "OperationCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
