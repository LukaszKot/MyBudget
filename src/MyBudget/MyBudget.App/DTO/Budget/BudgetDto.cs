using System;

namespace MyBudget.App.DTO.Budget
{
    public record BudgetDto(Guid Id, string Name, DateTime From, DateTime? To);
}