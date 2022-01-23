using Microsoft.AspNetCore.Mvc;

namespace MyBudget.App.Controllers
{
    [Route("/api/selects/")]
    public class ApiSelectController : ControllerBase
    {
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new {Test = "test"});
        }
    }
}