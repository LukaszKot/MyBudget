using System;
using System.Collections.Generic;
using MyBudget.App.Exceptions;

namespace MyBudget.App.Domain
{
    public class OperationCategory
    {
        public Guid Id { get; init; }
        public string Name { get; private set; }
        public IEnumerable<OperationTemplate> Operations { get; }
        
        // for serialization
        private OperationCategory()
        {
            
        }

        public OperationCategory(string name)
        {
            Id = Guid.NewGuid();
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