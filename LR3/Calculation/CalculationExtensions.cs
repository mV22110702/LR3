namespace LR3.Calculation
{
    public static class CalculationExtensions
    {
        public static IApplicationBuilder UseCalculation(this IApplicationBuilder builder)
        {
            return builder
                .UseMiddleware<CalculationArgsParserMiddleware>()
                .UseMiddleware<CalculationMiddleware>();

        }
    }
}
