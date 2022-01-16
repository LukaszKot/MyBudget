using System;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Commands.BudgetTemplate
{
    public record DeleteBudgetTemplate(
        [Required] Guid Id);
}