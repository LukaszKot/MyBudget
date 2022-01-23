using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBudget.App.Commands.Categories;
using MyBudget.App.Services;

namespace MyBudget.App.Controllers
{
    [Authorize]
    [Microsoft.AspNetCore.Components.Route("/categories/")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            command.UserId = UserId;
            await _categoryService.CreateCategory(command);
            return Redirect(command.FormUrl);
        }
        
        [HttpPost("update")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryNameCommand command)
        {
            await _categoryService.UpdateCategory(command);
            return Redirect(command.FormUrl);
        }
        
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand command)
        {
            await _categoryService.DeleteCategory(command);
            return Redirect(command.FormUrl);
        }
    }
}