using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBudget.App.Commands.Categories;
using MyBudget.App.Queries.Categories;
using MyBudget.App.Services;

namespace MyBudget.App.Controllers
{
    [Authorize]
    [Route("/api/selects/")]
    public class ApiSelectController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public ApiSelectController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("categories/{SearchText}")]
        public async Task<IActionResult> GetCategories([FromRoute] GetUserCategoriesQuery query)
        {
            query.UserId = UserId;
            var categories = await _categoryService.GetUserCategories(query);
            return Ok(categories);
        }

        [HttpPost("categories")]
        public async Task<IActionResult> AddCategories([FromBody] CreateCategoryCommand command)
        {
            command.UserId = UserId;
            var categoryId = await _categoryService.CreateCategory(command);
            return Ok(new { Id = categoryId });
        }
    }
}