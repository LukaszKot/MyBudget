using System;
using System.Collections.Generic;
using MyBudget.App.Exceptions;

namespace MyBudget.App.Domain
{
    public class OperationTemplate
    {
        public Guid Id { get; init; }
        public Guid? BudgetTemplateId { get; init; }
        public BudgetTemplate? BudgetTemplate { get; set; }
        public string Name { get; private set; }
        public decimal DefaultValue { get; set; }
        public ValueType ValueType { get; set; }
        public Guid? OperationCategoryId { get; set; }
        public OperationCategory? OperationCategory { get; set; }
        public IEnumerable<Operation> Operations { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        // for serialization
        private OperationTemplate()
        {
            
        }

        public OperationTemplate(Guid userId, string name, decimal defaultValue, ValueType valueType,
            Guid? budgetTemplateId = null, Guid? operationCategoryId = null)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            SetName(name);
            SetValue(defaultValue, valueType);
            BudgetTemplateId = budgetTemplateId;
            OperationCategoryId = operationCategoryId;
        }

        public void SetName(string name)
        {
            if (!RegexConsts.ObjectName.IsMatch(name))
            {
                throw new DomainException(DomainError.InvalidObjectName);
            }
            Name = name;
        }
        
        public void SetValue(decimal defaultValue, ValueType valueType)
        {
            if (valueType == ValueType.Percent && Math.Abs(defaultValue) > 100)
            {
                throw new DomainException(DomainError.InvalidOperationValue);
            }
            
            if (defaultValue > 0 && valueType == ValueType.Percent)
            {
                throw new DomainException(DomainError.InvalidOperationValue);
            }

            DefaultValue = defaultValue;
            ValueType = valueType;
        }
    }
}