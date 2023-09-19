using System.Net;
using LR3.CustomException;

namespace LR3.Calculation
{
    public class ZeroDivisionException : HttpException
    {
        public ZeroDivisionException(
            string operandName) : base(HttpStatusCode.BadRequest, $"<h1>Argument '{operandName.ToUpper()}': value cannot be zero</h1>")
        {
        }
    }
}
