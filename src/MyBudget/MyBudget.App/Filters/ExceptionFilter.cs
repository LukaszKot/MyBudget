using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBudget.App.Exceptions;

namespace MyBudget.App.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is DomainException domainException)
            {
                context.Result = new RedirectResult(context.HttpContext.Request.Path + "?Error=" +
                                                    domainException.ErrorType.ToString());
            }
        }
    }
}