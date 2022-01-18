using System;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.App.Commands.OperationTemplate
{
    public record DeleteOperationTemplateCommand(
        [Required] Guid Id,
        [Required] Guid BudgetTemplateId);
}