using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBudget.App.Commands.Categories;
using MyBudget.App.Commands.Operation;
using MyBudget.App.Queries.Categories;
using MyBudget.App.Queries.OperationTemplates;
using MyBudget.App.Services;

namespace MyBudget.App.Controllers
{
    [Authorize]
    [Route("/api/selects/")]
    public class ApiSelectController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IOperationTemplateService _operationTemplateService;
        private readonly IOperationService _operationService;

        public ApiSelectController(ICategoryService categoryService, IOperationTemplateService operationTemplateService, IOperationService operationService)
        {
            _categoryService = categoryService;
            _operationTemplateService = operationTemplateService;
            _operationService = operationService;
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
        
        [HttpGet("operation-templates/{SearchText}")]
        public async Task<IActionResult> GetOperationTemplates([FromRoute] GetOperationTemplatesQuery query)
        {
            query.UserId = UserId;
            var operationTemplates = await _operationTemplateService.GetOperationTemplates(query);
            return Ok(operationTemplates);
        }
        
        [HttpPost("operation")]
        public async Task<IActionResult> AddOperationBasedOnOperationTemplate([FromBody] CreateOperationFromTemplateCommand command)
        {
            command.UserId = UserId;
            await _operationService.CreateOperationFromTemplateAsync(command);
            return Ok();
        }
    }
}