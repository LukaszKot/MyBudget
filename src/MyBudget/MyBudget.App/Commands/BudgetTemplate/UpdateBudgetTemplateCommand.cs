using System;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Commands.BudgetTemplate
{
    public record UpdateBudgetTemplateCommand(
        [Required] Guid Id,
        [Required] string Name);
}