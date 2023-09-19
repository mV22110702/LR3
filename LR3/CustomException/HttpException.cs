using System.Net;

namespace LR3.CustomException
{
    public class HttpException : Exception
    {
        public readonly HttpStatusCode StatusCode;

        public HttpException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
