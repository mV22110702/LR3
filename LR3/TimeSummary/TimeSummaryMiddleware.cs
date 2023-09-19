namespace LR3.TimeSummary
{
    public class TimeSummaryMiddleware
    {
        private readonly RequestDelegate next;



        public TimeSummaryMiddleware(RequestDelegate next)

        {

            this.next = next;

        }

        public async Task InvokeAsync(HttpContext context, ITimeSummaryService timeSummaryService)
        {
           
            if (context.Request.Path.Equals("/time-summary"))
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync(
                    $"<h1> {timeSummaryService.GetTimeSummary(null)} </h1>"
                );
                return;
            }

            await next(context);
        }
    }
}
