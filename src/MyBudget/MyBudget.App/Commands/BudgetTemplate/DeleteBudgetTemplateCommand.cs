using System;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Commands.BudgetTemplate
{
    public record DeleteBudgetTemplateCommand(
        [Required] Guid Id);
}