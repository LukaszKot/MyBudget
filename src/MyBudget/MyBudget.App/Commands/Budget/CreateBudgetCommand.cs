using System;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Commands.Budget
{
    public record CreateBudgetCommand([Required] Guid BudgetTemplateId);
}