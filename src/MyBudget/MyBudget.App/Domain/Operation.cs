using System;

namespace MyBudget.App.Domain
{
    public class Operation
    {
        public Guid Id { get; init; }
        public Guid BudgetId { get; init; }
        public Budget Budget { get; init; }
        public Guid? OperationTemplateId { get; init; }
        public OperationTemplate? OperationTemplate { get; init; }
        public string? Name { get; set; }
        public decimal Value { get; set; }
        public ValueType ValueType { get; set; }
        public DateTime Date { get; set; }
        public Guid? OperaionCategoryId { get; init; }
        public OperationCategory? OperationCategory { get; set; }
        
        // for serialization
        private Operation()
        {
            
        }
    }
}