using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}