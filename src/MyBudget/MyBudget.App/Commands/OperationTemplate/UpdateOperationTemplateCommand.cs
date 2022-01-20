using System;
using System.ComponentModel.DataAnnotations;
using ValueType = MyBudget.App.Domain.ValueType;

namespace MyBudget.App.Commands.OperationTemplate
{
    public class UpdateOperationTemplateCommand : CommandWithServiceValidation
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal? DefaultValue { get; set; }
        public ValueType? ValueType { get; set; }
        public Guid? BudgetTemplateId { get; set; }
        public Guid? OperationCategoryId { get; set; }
    }
}