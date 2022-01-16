using System;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Queries.Budget
{
    public record GetBudgetOperationsQuery([Required] Guid Id);
}