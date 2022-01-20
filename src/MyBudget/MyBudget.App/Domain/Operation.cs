using System;
using MyBudget.App.Exceptions;

namespace MyBudget.App.Domain
{
    public class Operation
    {
        public Guid Id { get; init; }
        public Guid BudgetId { get; init; }
        public Budget Budget { get; }
        public Guid? OperationTemplateId { get; init; }
        public OperationTemplate? OperationTemplate { get; set; }
        public string Name { get; private set; }
        public decimal Value { get; private set; }
        public ValueType ValueType { get; private set; }
        public DateTime Date { get; private set; }
        public Guid? OperationCategoryId { get; set; }
        public OperationCategory? OperationCategory { get; set; }
        
        // for serialization
        private Operation()
        {
            
        }
        
        public Operation(Guid budgetId, string? name, decimal? value, ValueType? valueType,
            DateTime? date = null, Guid? operationCategoryId = null)
        {
            Id = Guid.NewGuid();
            BudgetId = budgetId;
            SetName(name);
            SetValue(value, valueType);
            Date = date ?? DateTime.UtcNow;
            OperationCategoryId = operationCategoryId;
        }

        public Operation(Guid budgetId, OperationTemplate operationTemplate)
        {
            Id = Guid.NewGuid();
            BudgetId = budgetId;
            Name = operationTemplate.Name;
            Value = operationTemplate.DefaultValue;
            ValueType = operationTemplate.ValueType;
            Date = DateTime.UtcNow;
            OperationCategoryId = operationTemplate.OperationCategoryId;
            OperationCategory = operationTemplate.OperationCategory;
        }
        
        public void SetName(string? name)
        {
            if (OperationCategoryId != null)
            {
                throw new DomainException(DomainError.CannotRenameOperationIfInheritsFromTemplate);
            }
            if (!RegexConsts.ObjectName.IsMatch(name))
            {
                throw new DomainException(DomainError.InvalidObjectName);
            }
            Name = name!;
        }

        public void SetValue(decimal? value, ValueType? valueType)
        {
            if (value == null || valueType == null)
            {
                throw new DomainException(DomainError.InvalidOperationValue);
            }
            if (valueType == ValueType.Percent && Math.Abs(value.Value) > 100)
            {
                throw new DomainException(DomainError.InvalidOperationValue);
            }

            if (value > 0 && valueType == ValueType.Percent)
            {
                throw new DomainException(DomainError.InvalidOperationValue);
            }

            Value = value.Value;
            ValueType = valueType.Value;
        }

        public void SetDate(DateTime? dateTime)
        {
            if (dateTime == null) throw new DomainException(DomainError.InvalidDate);
            Date = dateTime.Value;
        }
    }
}