using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBudget.App.Commands.Budget;
using MyBudget.App.Commands.Operation;
using MyBudget.App.Queries.Budget;
using MyBudget.App.Services;

namespace MyBudget.App.Controllers
{
    [Authorize]
    [Route("/budget/")]
    public class BudgetController : BaseController
    {
        private readonly IBudgetService _budgetService;
        private readonly IOperationService _operationService;

        public BudgetController(IBudgetService budgetService, IOperationService operationService)
        {
            _budgetService = budgetService;
            _operationService = operationService;
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
        
        [HttpPost("operation")]
        public async Task<IActionResult> CreateBudgetOperation(CreateOperationCommand command)
        {
            await _operationService.CreateOperationAsync(command);
            return Redirect($"/budget/{command.BudgetId}");
        }
        
        [HttpPost("operation/edit")]
        public async Task<IActionResult> UpdateBudgetOperation(UpdateOperationCommand command)
        {
            await _operationService.UpdateOperationAsync(command);
            return Redirect($"/budget/{command.BudgetId}");
        }
        
        [HttpPost("operation/delete")]
        public async Task<IActionResult> DeleteBudgetOperation(DeleteOperationCommand command)
        {
            await _operationService.DeleteOperationAsync(command);
            return Redirect($"/budget/{command.BudgetId}");
        }
    }
}