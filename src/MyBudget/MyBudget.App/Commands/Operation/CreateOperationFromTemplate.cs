using System;
using System.ComponentModel.DataAnnotations;
using ValueType = MyBudget.App.Domain.ValueType;

namespace MyBudget.App.Commands.Operation
{
    public record CreateOperationFromTemplate(
        [Required] Guid BudgetId,
        [Required] Guid OperationTemplateId);
}