using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBudget.App.Domain
{
    public class Budget
    {
        public Guid Id { get; init; }
        public BudgetTemplate? BudgetTemplate { get; set; }
        public Guid? BudgetTemplateId { get; init; }
        public BudgetType BudgetType { get; set; }
        public DateTime From { get; init; }
        public DateTime? To { get; private set; }
        public IEnumerable<Operation> Operations { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        // for serialization
        private Budget()
        {
            
        }

        public Budget(BudgetTemplate budgetTemplate)
        {
            var newId = Guid.NewGuid();
            Id = newId;
            Name = budgetTemplate.Name;
            BudgetTemplateId = budgetTemplate.Id;
            BudgetType = BudgetType.Active;
            From = DateTime.UtcNow;
            Operations = budgetTemplate.OperationTemplates.Select(x => new Operation(newId, x)).ToList();
            UserId = budgetTemplate.UserId;
        }

        public void Archive()
        {
            BudgetType = BudgetType.Historical;
            To = DateTime.UtcNow;
        }

        public decimal GetTotal()
        {
            var income = GetIncome();
            var expenses = Operations
                .Where(x => x.Value < 0)
                .Sum(x => x.ValueType == ValueType.FixedAmount ? x.Value : x.Value/100 * income);
            return income + expenses;
        }

        public decimal GetIncome()
        {
            return Operations
                .Where(x => x.Value > 0)
                .Sum(x => x.Value);
        }
    }
}