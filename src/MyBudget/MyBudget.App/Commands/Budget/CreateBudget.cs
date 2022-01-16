using System;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Commands.Budget
{
    public record CreateBudget([Required] Guid BudgetTemplateId);
}