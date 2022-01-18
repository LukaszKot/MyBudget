using System;
using System.ComponentModel.DataAnnotations;
using ValueType = MyBudget.App.Domain.ValueType;

namespace MyBudget.App.Commands.Operation
{
    public record UpdateOperationCommand(
        [Required] Guid Id, 
        [Required] string Name, 
        [Required] decimal DefaultValue, 
        [Required] ValueType ValueType,
        [Required] DateTime Date,
        [Required] Guid BudgetId,
        Guid? OperationCategoryId);
}