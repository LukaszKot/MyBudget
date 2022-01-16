using System;

namespace MyBudget.App.DTO.Budget
{
    public record OperationDto(
        Guid Id, 
        string Name,
        decimal DefaultValue, 
        ValueType ValueType,
        DateTime Date,
        Guid? OperationTemplateId, 
        Guid? OperationCategoryId, 
        string? CategoryName);
}