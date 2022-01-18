using System;
using System.ComponentModel.DataAnnotations;
using ValueType = MyBudget.App.Domain.ValueType;

namespace MyBudget.App.Commands.OperationTemplate
{
    public record CreateOperationTemplateCommand(
        [Required] string Name,
        [Required] decimal DefaultValue,
        [Required] ValueType ValueType,
        Guid? BudgetTemplateId,
        Guid? OperationCategoryId)
    {
        public Guid UserId { get; set; }
    }
}