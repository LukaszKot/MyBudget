using System;
using System.Collections.Generic;
using MyBudget.App.Exceptions;

namespace MyBudget.App.Domain
{
    public class OperationCategory
    {
        public Guid Id { get; init; }
        public string Name { get; private set; }
        public IEnumerable<OperationTemplate> OperationTemplates { get; set; }
        public IEnumerable<Operation> Operations { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        // for serialization
        private OperationCategory()
        {
            
        }

        public OperationCategory(string? name, Guid? userId)
        {
            Id = Guid.NewGuid();
            SetName(name);
            UserId = userId!.Value;
        }

        public void SetName(string? name)
        {
            if (!RegexConsts.ObjectName.IsMatch(name))
            {
                throw new DomainException(DomainError.InvalidObjectName);
            }
            Name = name;
        }
    }
}