using System;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Queries.BudgetTemplate
{
    public record GetBudgetTemplateOperationsQuery([Required] Guid Id);
}