using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBudget.App.Migrations
{
    public partial class RelationshipFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_OperationCategories_OperationCategoryId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_OperationCategoryId",
                table: "Operations");
        }
    }
}
