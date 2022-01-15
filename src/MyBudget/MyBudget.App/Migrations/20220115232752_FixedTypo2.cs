using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBudget.App.Migrations
{
    public partial class FixedTypo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OperaionCategoryId",
                table: "Operations",
                newName: "OperationCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OperationCategoryId",
                table: "Operations",
                newName: "OperaionCategoryId");
        }
    }
}
