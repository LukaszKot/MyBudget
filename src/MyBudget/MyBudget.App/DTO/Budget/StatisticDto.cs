using System;

namespace MyBudget.App.DTO.Budget
{
    public record StatisticDto(Guid OperationCategoryId, string CategoryName, decimal AggregatedSum);
}