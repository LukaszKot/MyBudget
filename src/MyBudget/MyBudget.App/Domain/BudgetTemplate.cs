using System;
using System.Collections.Generic;
using MyBudget.App.Exceptions;

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

        public BudgetTemplate(Guid userId, string name)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            SetName(name);
        }

        public void SetName(string name)
        {
            if (!RegexConsts.ObjectName.IsMatch(name))
            {
                throw new DomainException(DomainError.InvalidObjectName);
            }
            Name = name;
        }
    }
}