using System;
using System.Runtime.Serialization;

namespace MyBudget.App.DTO.Budget
{
    [DataContract]
    public class StatisticDto
    {
        public Guid? OperationCategoryId { get; set; }
        [DataMember(Name = "label")] 
        public string? CategoryName { get; set; }
        [DataMember(Name = "y")]
        public decimal AggregatedSum { get; set; }

        public StatisticDto(Guid? operationCategoryId, string? categoryName, decimal aggregatedSum)
        {
            OperationCategoryId = operationCategoryId;
            CategoryName = categoryName;
            AggregatedSum = aggregatedSum;
        }
    }
        
}