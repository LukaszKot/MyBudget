using System;
using System.Collections.Generic;
using System.Linq;

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

        public Budget(BudgetTemplate budgetTemplate)
        {
            var newId = Guid.NewGuid();
            Id = newId;
            BudgetTemplate = budgetTemplate;
            BudgetTemplateId = budgetTemplate.Id;
            BudgetType = BudgetType.Active;
            From = DateTime.UtcNow;
            Operations = budgetTemplate.OperationTemplates.Select(x => new Operation(newId, x));
        }

        public void Archive()
        {
            BudgetType = BudgetType.Historical;
            To = DateTime.UtcNow;
        }
    }
}