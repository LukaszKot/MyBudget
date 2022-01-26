using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBudget.App.Migrations
{
    public partial class AddedOnDeleteSetNullToTableOperationCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_OperationCategories_OperationCategoryId",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationTemplates_OperationCategories_OperationCategoryId",
                table: "OperationTemplates");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_OperationCategories_OperationCategoryId",
                table: "Operations",
                column: "OperationCategoryId",
                principalTable: "OperationCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationTemplates_OperationCategories_OperationCategoryId",
                table: "OperationTemplates",
                column: "OperationCategoryId",
                principalTable: "OperationCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_OperationCategories_OperationCategoryId",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationTemplates_OperationCategories_OperationCategoryId",
                table: "OperationTemplates");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_OperationCategories_OperationCategoryId",
                table: "Operations",
                column: "OperationCategoryId",
                principalTable: "OperationCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationTemplates_OperationCategories_OperationCategoryId",
                table: "OperationTemplates",
                column: "OperationCategoryId",
                principalTable: "OperationCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
