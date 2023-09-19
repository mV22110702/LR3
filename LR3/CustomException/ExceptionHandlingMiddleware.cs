using Microsoft.Extensions.Logging;
using System.Net;

namespace LR3.CustomException
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;



        public ExceptionHandlingMiddleware(RequestDelegate next)

        {

            this.next = next;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (HttpException exception)
            {
                var response = context.Response;
                response.ContentType = "text/html";

                response.StatusCode = (int)exception.StatusCode;
                await response.WriteAsync($"<h1>{exception.Message}</h1>");
            }

        }
    }
}
