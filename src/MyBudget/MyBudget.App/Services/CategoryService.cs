using System.Linq;
using System.Threading.Tasks;
using MyBudget.App.Commands.Categories;
using MyBudget.App.Domain;
using MyBudget.App.DTO.Budget;
using MyBudget.App.Queries.Categories;
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

        public async Task UpdateCategory(UpdateCategoryNameCommand command)
        {
            var category = await _categoryRepository.Get(command.Id);
            category.SetName(command.Name);
            await _categoryRepository.Update(category);
        }

        public async Task DeleteCategory(DeleteCategoryCommand command)
        {
            var category = await _categoryRepository.Get(command.Id);
            await _categoryRepository.Delete(category);
        }

        public async Task<GetUserCategoriesQueryResponse> GetUserCategories(GetUserCategoriesQuery query)
        {
            var categories = await _categoryRepository.GetAll(query.UserId!.Value, query.SearchText);
            return new()
            {
                Categories = categories.Select(x => new CategoryDto(x.Id, x.Name))
            };
        }
    }
}