using System;
using System.Collections.Generic;

namespace MyBudget.App.Domain
{
    public class Budget
    {
        public Guid Id { get; init; }
        public BudgetTemplate BudgetTemplate { get; set; }
        public Guid BudgetTemplateId { get; set; }
        public BudgetType BudgetType { get; private set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public IEnumerable<Operation> Operations { get; private set; }

        // for serialization
        private Budget()
        {
            
        }
    }
}