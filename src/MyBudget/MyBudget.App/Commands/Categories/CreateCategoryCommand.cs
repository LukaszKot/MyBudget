using System;

namespace MyBudget.App.Commands.Categories
{
    public class CreateCategoryCommand : CommandWithServiceValidation
    {
        public string? Name { get; set; }
        public Guid? UserId { get; set; }
    }
}