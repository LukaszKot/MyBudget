using System.Threading.Tasks;
using MyBudget.App.Commands.Categories;
using MyBudget.App.Queries.Categories;

namespace MyBudget.App.Services
{
    public interface ICategoryService
    {
        Task CreateCategory(CreateCategoryCommand command);
        Task UpdateCategory(UpdateCategoryNameCommand command);
        Task DeleteCategory(DeleteCategoryCommand command);
        Task<GetUserCategoriesQueryResponse> GetUserCategories(GetUserCategoriesQuery query);
    }
}