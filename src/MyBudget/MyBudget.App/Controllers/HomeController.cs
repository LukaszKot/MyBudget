using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBudget.App.Services;

namespace MyBudget.App.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IBudgetService _budgetService;

        public HomeController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        
        public async Task<IActionResult> Index()
        {
            var model = await _budgetService.GetBudgetsAsync(UserId);
            return View(model);
        }
    }
}