using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBudget.App.Commands.Budget;
using MyBudget.App.Queries.Budget;
using MyBudget.App.Services;

namespace MyBudget.App.Controllers
{
    [Authorize]
    [Route("/budget/")]
    public class BudgetController : BaseController
    {
        private readonly IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateBudget(CreateBudgetCommand command)
        {
            var budgetCreatedEvent = await _budgetService.CreateBudgetAsync(command);
            return Redirect($"/budget/{budgetCreatedEvent.Id}");
        }
        
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetBudgetOperations([FromRoute] GetBudgetOperationsQuery query)
        {
            var result = await _budgetService.GetBudgetOperationsAsync(query);
            return View("Budget", result);
        }
    }
}