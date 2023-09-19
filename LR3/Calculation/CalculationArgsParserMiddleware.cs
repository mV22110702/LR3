using static LR3.Calculation.CalculationConstants;
using LR3.CustomException;

namespace LR3.Calculation
{
    public class CalculationArgsParserMiddleware
    {
        private readonly RequestDelegate next;



        public CalculationArgsParserMiddleware(RequestDelegate next)

        {

            this.next = next;

        }

        private double ParseValueFromContext(HttpContext context, string argumentName)
        {
            var isArgumentParsed = double.TryParse(
                context.Request.Query[argumentName],
                out double argumentValue
            );


            if (!isArgumentParsed)
            {
                throw new InvalidCalculationOperandException(argumentName);
            }

            return (double)argumentValue;
        }

        private void CheckCalculationPath(HttpContext context)
        {
            var currentRoute = context.Request.Path;
            var allowedRoutes = CalculationConstants.Paths.Values.ToList();
            if (
                !allowedRoutes.Contains(currentRoute)
                )
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest, $"<h1>Invalid route. Provided: '{currentRoute}', allowed: '{string.Join(", ", allowedRoutes)}'</h1>");
            }
        }

        private void CheckDivisionByZero(HttpContext context, string secondArgName, double secondArgValue) {
            var currentRoute = context.Request.Path;
            var divisionRoute = CalculationConstants.Paths[CalculationConstants.Path.DIVIDE];
            if (
                context.Request.Path.Equals(divisionRoute) &&
                secondArgValue == 0
                )
            {
                throw new ZeroDivisionException(secondArgName);
            }
        }

        public async Task InvokeAsync(HttpContext context)
        {
            CheckCalculationPath(context);

            var firstArgName = ArgNames[ArgName.FIRST];
            var firstArgValue = ParseValueFromContext(context, firstArgName);

            var secondArgName = ArgNames[ArgName.SECOND];
            var secondArgValue = ParseValueFromContext(context, secondArgName);

            CheckDivisionByZero(context, secondArgName, secondArgValue);

            context.Items.Add(firstArgName, firstArgValue);
            context.Items.Add(secondArgName, secondArgValue);

            await next(context);
        }
    }
}
