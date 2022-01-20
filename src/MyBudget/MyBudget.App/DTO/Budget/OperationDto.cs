using System;
using ValueType = MyBudget.App.Domain.ValueType;

namespace MyBudget.App.DTO.Budget
{
    public record OperationDto(
        Guid Id, 
        string Name,
        decimal Value, 
        ValueType ValueType,
        DateTime Date,
        Guid? OperationTemplateId, 
        Guid? OperationCategoryId, 
        string? CategoryName,
        decimal RealValue);
}