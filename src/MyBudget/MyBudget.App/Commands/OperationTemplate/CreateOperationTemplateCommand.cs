using System;
using System.ComponentModel.DataAnnotations;
using ValueType = MyBudget.App.Domain.ValueType;

namespace MyBudget.App.Commands.OperationTemplate
{
    public class CreateOperationTemplateCommand : CommandWithServiceValidation
    {
        public string? Name { get; set; }
        public Guid? UserId { get; set; }
        public decimal? DefaultValue { get; set; }
        public ValueType? ValueType { get; set; }
        public Guid? BudgetTemplateId { get; set; }
        public Guid? OperationCategoryId { get; set; }
    }
}