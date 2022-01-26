using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBudget.App.Migrations
{
    public partial class AddedOnDeleteNoActionToTableUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetTemplates_Users_UserId",
                table: "BudgetTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationCategories_Users_UserId",
                table: "OperationCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationTemplates_Users_UserId",
                table: "OperationTemplates");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetTemplates_Users_UserId",
                table: "BudgetTemplates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationCategories_Users_UserId",
                table: "OperationCategories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationTemplates_Users_UserId",
                table: "OperationTemplates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetTemplates_Users_UserId",
                table: "BudgetTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationCategories_Users_UserId",
                table: "OperationCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationTemplates_Users_UserId",
                table: "OperationTemplates");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetTemplates_Users_UserId",
                table: "BudgetTemplates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationCategories_Users_UserId",
                table: "OperationCategories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationTemplates_Users_UserId",
                table: "OperationTemplates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
