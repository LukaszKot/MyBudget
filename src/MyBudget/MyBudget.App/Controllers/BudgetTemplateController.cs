using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBudget.App.Commands.BudgetTemplate;
using MyBudget.App.Queries.BudgetTemplate;
using MyBudget.App.Services;

namespace MyBudget.App.Controllers
{
    [Authorize]
    [Route("/budget-template/")]
    public class BudgetTemplateController : BaseController
    {
        private readonly IBudgetTemplateService _budgetTemplateService;

        public BudgetTemplateController(IBudgetTemplateService budgetTemplateService)
        {
            _budgetTemplateService = budgetTemplateService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBudgetTemplate(CreateBudgetTemplateCommand command)
        {
            command.UserId = UserId;
            var budgetTemplateCreatedEvent = await _budgetTemplateService.CreateBudgetTemplateAsync(command);
            return Redirect($"budget-template/{budgetTemplateCreatedEvent.Id}");
        }
        
        [HttpGet]
        public async Task<IActionResult> GetBudgetTemplateOperations(GetBudgetTemplateOperationsQuery query)
        {
            var result = await _budgetTemplateService.GetBudgetTemplateOperationsAsync(query);
            return View("BudgetTemplate", query);
        }
    }
}