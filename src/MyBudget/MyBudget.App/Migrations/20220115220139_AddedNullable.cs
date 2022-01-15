using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBudget.App.Migrations
{
    public partial class AddedNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationTemplates_OperationCategories_OperationCategoryId",
                table: "OperationTemplates");

            migrationBuilder.AlterColumn<Guid>(
                name: "OperationCategoryId",
                table: "OperationTemplates",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BudgetTemplateId",
                table: "OperationTemplates",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "OperaionCategoryId",
                table: "OperationTemplates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OperationTemplateId",
                table: "Operations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "OperaionCategoryId",
                table: "Operations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OperationCategoryId",
                table: "Operations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "To",
                table: "Budgets",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

            migrationBuilder.AddForeignKey(
                name: "FK_OperationTemplates_OperationCategories_OperationCategoryId",
                table: "OperationTemplates",
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

            migrationBuilder.DropForeignKey(
                name: "FK_OperationTemplates_OperationCategories_OperationCategoryId",
                table: "OperationTemplates");

            migrationBuilder.DropIndex(
                name: "IX_Operations_OperationCategoryId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "OperaionCategoryId",
                table: "OperationTemplates");

            migrationBuilder.DropColumn(
                name: "OperaionCategoryId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "OperationCategoryId",
                table: "Operations");

            migrationBuilder.AlterColumn<Guid>(
                name: "OperationCategoryId",
                table: "OperationTemplates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BudgetTemplateId",
                table: "OperationTemplates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OperationTemplateId",
                table: "Operations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "To",
                table: "Budgets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationTemplates_OperationCategories_OperationCategoryId",
                table: "OperationTemplates",
                column: "OperationCategoryId",
                principalTable: "OperationCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
