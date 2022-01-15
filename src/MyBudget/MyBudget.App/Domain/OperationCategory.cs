using System;
using System.Collections.Generic;

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
    }
}