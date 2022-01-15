using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBudget.App.Migrations
{
    public partial class AddedTabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgetTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetTemplates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BudgetTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BudgetType = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgets_BudgetTemplates_BudgetTemplateId",
                        column: x => x.BudgetTemplateId,
                        principalTable: "BudgetTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BudgetTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValueType = table.Column<int>(type: "int", nullable: false),
                    OperationCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationTemplates_BudgetTemplates_BudgetTemplateId",
                        column: x => x.BudgetTemplateId,
                        principalTable: "BudgetTemplates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OperationTemplates_OperationCategories_OperationCategoryId",
                        column: x => x.OperationCategoryId,
                        principalTable: "OperationCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationTemplates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BudgetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValueType = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operations_OperationTemplates_OperationTemplateId",
                        column: x => x.OperationTemplateId,
                        principalTable: "OperationTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_BudgetTemplateId",
                table: "Budgets",
                column: "BudgetTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetTemplates_UserId",
                table: "BudgetTemplates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_BudgetId",
                table: "Operations",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_OperationTemplateId",
                table: "Operations",
                column: "OperationTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationTemplates_BudgetTemplateId",
                table: "OperationTemplates",
                column: "BudgetTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationTemplates_OperationCategoryId",
                table: "OperationTemplates",
                column: "OperationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationTemplates_UserId",
                table: "OperationTemplates",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "OperationTemplates");

            migrationBuilder.DropTable(
                name: "BudgetTemplates");

            migrationBuilder.DropTable(
                name: "OperationCategories");
        }
    }
}
