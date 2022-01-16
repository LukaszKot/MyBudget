using System;
using System.ComponentModel.DataAnnotations;
using ValueType = MyBudget.App.Domain.ValueType;

namespace MyBudget.App.Commands.OperationTemplate
{
    public record CreateOperationTemplate(
        [Required] Guid UserId, 
        [Required] string Name, 
        [Required] decimal DefaultValue, 
        [Required] ValueType ValueType,
        Guid? BudgetTemplateId, 
        Guid? OperationCategoryId);
}