using System;
using ValueType = MyBudget.App.Domain.ValueType;

namespace MyBudget.App.DTO.Budget
{
    public record OperationTemplateDto(
        Guid Id, 
        string Name, 
        decimal DefaultValue, 
        ValueType ValueType, 
        Guid? BudgetTemplateId, 
        Guid? OperationCategoryId, 
        string? CategoryName);
}