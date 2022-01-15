using System;
using System.Collections;
using System.Collections.Generic;

namespace MyBudget.App.Domain
{
    public class BudgetTemplate
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public User User { get; }
        public string Name { get; private set; }
        public IEnumerable<OperationTemplate> OperationTemplates { get; private set; }
        public IEnumerable<Budget> Budgets { get; private set; }

        // for serialization
        private BudgetTemplate()
        {
            
        }
    }
}