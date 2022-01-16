using System;
using System.ComponentModel.DataAnnotations;
using ValueType = MyBudget.App.Domain.ValueType;

namespace MyBudget.App.Commands.Operation
{
    public record CreateOperationCommand(
        [Required] Guid BudgetId, 
        [Required] string Name, 
        [Required] decimal DefaultValue, 
        [Required] ValueType ValueType,
        DateTime? Date,
        Guid? OperationCategoryId);
}