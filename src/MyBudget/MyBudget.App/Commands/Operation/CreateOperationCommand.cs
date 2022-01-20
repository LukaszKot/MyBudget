using System;
using ValueType = MyBudget.App.Domain.ValueType;

namespace MyBudget.App.Commands.Operation
{
    public class CreateOperationCommand : CommandWithServiceValidation
    {
        public Guid? BudgetId { get; set; }
        public string? Name { get; set; }
        public decimal? DefaultValue { get; set; }
        public ValueType? ValueType { get; set; }
        public DateTime? Date { get; set; }
        public Guid? OperationCategoryId { get; set; }
    }
}