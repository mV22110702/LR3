using static LR3.Calculation.CalculationConstants;

namespace LR3.Calculation
{
    public class CalculationMiddleware
    {
        private readonly RequestDelegate next;



        public CalculationMiddleware(RequestDelegate next)

        {

            this.next = next;

        }

        private double GetParsedValueFromContext(HttpContext context, ArgName argument)
        {
            var argumentName = ArgNames[argument];

            var isArgParsed = context.Items.TryGetValue(argumentName, out var valueObject);

            if (!isArgParsed || valueObject == null)
            {
                throw new InvalidCalculationOperandException(argumentName);
            }

            return (double)valueObject;
        }

        public async Task Invoke(HttpContext context, ICalculationService calculationService)

        {


            double firstValue = GetParsedValueFromContext(context, ArgName.FIRST);
            double secondValue = GetParsedValueFromContext(context, ArgName.SECOND);


            context.Response.ContentType = "text/html;charset=utf-8";

            var sumPath = Paths[CalculationConstants.Path.SUM];
            var subtractPath = Paths[CalculationConstants.Path.SUBTRACT];
            var multiplyPath = Paths[CalculationConstants.Path.MULTIPLY];
            var dividePath = Paths[CalculationConstants.Path.DIVIDE];
            var powPath = Paths[CalculationConstants.Path.POW];

            double? result = null;

            if (context.Request.Path.Equals(sumPath))
            {
                result = calculationService.Sum(firstValue, secondValue);
            }
            else if (context.Request.Path.Equals(subtractPath))
            {
                result = calculationService.Subtract(firstValue, secondValue);
            }
            else if (context.Request.Path.Equals(multiplyPath))
            {
                result = calculationService.Multiply(firstValue, secondValue);
            }
            else if (context.Request.Path.Equals(dividePath))
            {
                result = calculationService.Divide(firstValue, secondValue);
            }
            else if (context.Request.Path.Equals(powPath))
            {
                result = calculationService.Pow(firstValue, secondValue);
            }

            await context.Response.WriteAsync($"<h1>Result: {result}</h1>");

        }
    }
}
