using System;
using System.Collections.Generic;
using MyBudget.App.DTO.Budget;

namespace MyBudget.App.Queries.Budget
{
    public record GetBudgetOperationsQueryResponse(
        Guid Id, 
        string Name,
        DateTime From,
        decimal Total,
        IEnumerable<OperationDto> Operations);
}