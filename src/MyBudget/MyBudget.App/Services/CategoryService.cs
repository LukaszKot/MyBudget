using System.Threading.Tasks;
using MyBudget.App.Commands.Categories;
using MyBudget.App.Domain;
using MyBudget.App.Repositories;

namespace MyBudget.App.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        
        public async Task CreateCategory(CreateCategoryCommand command)
        {
            var category = new OperationCategory(command.Name, command.UserId);
            await _categoryRepository.Create(category);
        }
    }
}