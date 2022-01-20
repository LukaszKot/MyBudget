using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyBudget.App.Middleware
{
    public class BodyRewindMiddleware
    {
        private readonly RequestDelegate _next;


        public BodyRewindMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();
            }
            catch {}

            await _next(context);
            context.Request.Body.Dispose();
        }
    }
}