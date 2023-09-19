using System.Net;
using LR3.CustomException;

namespace LR3.Calculation
{
    public class InvalidCalculationOperandException : HttpException
    {
        public InvalidCalculationOperandException(
            string operandName) : base(HttpStatusCode.BadRequest, $"<h1>Argument '{operandName.ToUpper()}': value is invalid or missing</h1>")
        {
        }
    }
}
