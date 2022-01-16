using System;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Commands.BudgetTemplate
{
    public record UpdateBudgetTemplate(
        [Required] Guid Id,
        [Required] string Name);
}