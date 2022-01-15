using System;
using System.Collections.Generic;

namespace MyBudget.App.Domain
{
    public class Budget
    {
        public Guid Id { get; init; }
        public BudgetTemplate BudgetTemplate { get; }
        public Guid BudgetTemplateId { get; init; }
        public BudgetType BudgetType { get; set; }
        public DateTime From { get; init; }
        public DateTime? To { get; private set; }
        public IEnumerable<Operation> Operations { get; private set; }

        // for serialization
        private Budget()
        {
            
        }
    }
}