using System;

namespace MyBudget.App.Domain
{
    public class Operation
    {
        public Guid Id { get; init; }
        public Guid BudgetId { get; init; }
        public Budget Budget { get; }
        public Guid? OperationTemplateId { get; init; }
        public OperationTemplate? OperationTemplate { get; }
        public string? Name { get; private set; }
        public decimal Value { get; private set; }
        public ValueType ValueType { get; private set; }
        public DateTime Date { get; private set; }
        public Guid? OperaionCategoryId { get; set; }
        public OperationCategory? OperationCategory { get; }
        
        // for serialization
        private Operation()
        {
            
        }
    }
}