using System;

namespace MyBudget.App.Commands.Categories
{
    public class UpdateCategoryNameCommand : CommandWithServiceValidation
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}