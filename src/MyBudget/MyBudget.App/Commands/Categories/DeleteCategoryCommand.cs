using System;

namespace MyBudget.App.Commands.Categories
{
    public class DeleteCategoryCommand : CommandWithServiceValidation
    {
        public Guid Id { get; set; }
    }
}