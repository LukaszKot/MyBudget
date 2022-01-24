using System;

namespace MyBudget.App.Queries.Categories
{
    public class GetUserCategoriesQuery
    {
        public Guid? UserId { get; set; }
        public string SearchText { get; set; }
    }
}