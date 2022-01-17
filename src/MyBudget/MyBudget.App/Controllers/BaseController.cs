using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace MyBudget.App.Controllers
{
    public class BaseController : Controller
    {
        protected Guid UserId
        {
            get
            {
                var claim = User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                return new Guid(claim!.Value);
            }
        }
    }
}