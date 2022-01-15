using System;
using System.Collections.Generic;

namespace MyBudget.App.Domain
{
    public class OperationCategory
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public IEnumerable<OperationTemplate> Operations { get; set; }
        
        // for serialization
        private OperationCategory()
        {
            
        }
    }
}