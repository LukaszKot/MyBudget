using System;
using System.ComponentModel.DataAnnotations;
using ValueType = MyBudget.App.Domain.ValueType;

namespace MyBudget.App.Commands.OperationTemplate
{
    public record DeleteOperationTemplate(
        [Required] Guid Id);
}