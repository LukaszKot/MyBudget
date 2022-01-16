using System;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Commands.BudgetTemplate
{
    public record CreateBudgetTemplate(
        [Required] Guid UserId,
        [Required] string Name);
}