using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
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
                var content = GetRequestBodyContent(context.HttpContext.Request).Result;
                var queryString = HttpUtility.ParseQueryString(content);
                var formUrl = queryString["FormUrl"];
                context.Result = new RedirectResult((formUrl ?? context.HttpContext.Request.Path) + "?Error=" +
                                                    domainException.ErrorType);
            }
            
        }

        private async Task<string> GetRequestBodyContent(HttpRequest httpRequest)
        {
            string bodyStr = "";
            httpRequest.EnableBuffering();
            using (StreamReader reader 
                   = new StreamReader(httpRequest.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyStr = await reader.ReadToEndAsync();
            }
            httpRequest.Body.Position = 0;
            return bodyStr;
        }
    }
}