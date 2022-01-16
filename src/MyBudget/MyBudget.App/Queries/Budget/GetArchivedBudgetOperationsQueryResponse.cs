using System;
using System.Collections.Generic;
using MyBudget.App.DTO.Budget;

namespace MyBudget.App.Queries.Budget
{
    public record GetArchivedBudgetOperationsQueryResponse(
        Guid Id, 
        string Name,
        DateTime From,
        DateTime To,
        decimal Total,
        IEnumerable<OperationDto> Operations,
        StatisticsDto Statistics);
}