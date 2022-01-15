using System;
using System.Collections.Generic;

namespace MyBudget.App.Domain
{
    public class OperationTemplate
    {
        public Guid Id { get; init; }
        public Guid? BudgetTemplateId { get; init; }
        public BudgetTemplate? BudgetTemplate { get; init; }
        public string Name { get; set; }
        public decimal DefaultValue { get; set; }
        public ValueType ValueType { get; set; }
        public Guid? OperaionCategoryId { get; init; }
        public OperationCategory? OperationCategory { get; set; }
        public IEnumerable<Operation> Operations { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        // for serialization
        private OperationTemplate()
        {
            
        }
    }
}