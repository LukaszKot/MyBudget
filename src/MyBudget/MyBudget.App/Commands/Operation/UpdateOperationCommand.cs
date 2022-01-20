using System;
using ValueType = MyBudget.App.Domain.ValueType;

namespace MyBudget.App.Commands.Operation
{
    public class UpdateOperationCommand : CommandWithServiceValidation
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public decimal? DefaultValue { get; set; }
        public ValueType? ValueType { get; set; }
        public DateTime? Date { get; set; }
        public Guid? BudgetId { get; set; }
        public Guid? OperationCategoryId { get; set; }
    }
        
}