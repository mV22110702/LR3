namespace LR3.TimeSummary
{
    public static class TimeSummaryExtensions
    {
        public static IApplicationBuilder UseTimeSummary(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeSummaryMiddleware>();

        }
    }
}
