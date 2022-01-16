using System;
using System.ComponentModel.DataAnnotations;
using ValueType = MyBudget.App.Domain.ValueType;

namespace MyBudget.App.Commands.OperationTemplate
{
    public record UpdateOperationTemplate(
        [Required] Guid Id, 
        [Required] string Name, 
        [Required] decimal DefaultValue, 
        [Required] ValueType ValueType, 
        Guid? OperationCategoryId);
}