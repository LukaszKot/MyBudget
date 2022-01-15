using System;
using System.Collections.Generic;

namespace MyBudget.App.Domain
{
    public class OperationTemplate
    {
        public Guid Id { get; init; }
        public Guid? BudgetTemplateId { get; init; }
        public BudgetTemplate? BudgetTemplate { get; }
        public string Name { get; private set; }
        public decimal DefaultValue { get; set; }
        public ValueType ValueType { get; set; }
        public Guid? OperationCategoryId { get; set; }
        public OperationCategory? OperationCategory { get; }
        public IEnumerable<Operation> Operations { get; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        // for serialization
        private OperationTemplate()
        {
            
        }
    }
}