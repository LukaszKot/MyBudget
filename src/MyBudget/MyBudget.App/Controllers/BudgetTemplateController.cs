using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBudget.App.Commands.BudgetTemplate;
using MyBudget.App.Commands.OperationTemplate;
using MyBudget.App.Queries.BudgetTemplate;
using MyBudget.App.Services;

namespace MyBudget.App.Controllers
{
    [Authorize]
    [Route("/budget-template/")]
    public class BudgetTemplateController : BaseController
    {
        private readonly IBudgetTemplateService _budgetTemplateService;
        private readonly IOperationTemplateService _operationTemplateService;

        public BudgetTemplateController(IBudgetTemplateService budgetTemplateService, IOperationTemplateService operationTemplateService)
        {
            _budgetTemplateService = budgetTemplateService;
            _operationTemplateService = operationTemplateService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBudgetTemplate(CreateBudgetTemplateCommand command)
        {
            command.UserId = UserId;
            var budgetTemplateCreatedEvent = await _budgetTemplateService.CreateBudgetTemplateAsync(command);
            return Redirect($"budget-template/{budgetTemplateCreatedEvent.Id}");
        }
        
        [HttpPost("edit")]
        public async Task<IActionResult> UpdateBudgetTemplate(UpdateBudgetTemplateCommand command)
        {
            await _budgetTemplateService.UpdateBudgetTemplateAsync(command);
            return Redirect($"/");
        }
        
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetBudgetTemplateOperations([FromRoute] GetBudgetTemplateOperationsQuery query)
        {
            var result = await _budgetTemplateService.GetBudgetTemplateOperationsAsync(query);
            return View("BudgetTemplate", result);
        }
        
        [HttpPost("operation-template")]
        public async Task<IActionResult> CreateOperationTemplate(CreateOperationTemplateCommand command)
        {
            command.UserId = UserId;
            await _operationTemplateService.CreateOperationTemplateAsync(command);
            return Redirect($"{command.BudgetTemplateId}");
        }
        
        [HttpPost("operation-template/edit")]
        public async Task<IActionResult> UpdateOperationTemplate(UpdateOperationTemplateCommand command)
        {
            await _operationTemplateService.UpdateOperationTemplateAsync(command);
            return Redirect($"../{command.BudgetTemplateId}");
        }
        
        [HttpPost("operation-template/delete")]
        public async Task<IActionResult> DeleteOperationTemplate(DeleteOperationTemplateCommand command)
        {
            await _operationTemplateService.DeleteOperationTemplateAsync(command);
            return Redirect($"../{command.BudgetTemplateId}");
        }
    }
}