using System.Collections.Generic;
using MyBudget.App.DTO.Budget;

namespace MyBudget.App.Queries.Categories
{
    public class GetUserCategoriesQueryResponse
    {
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}