using System.Net;

namespace Infrastructure.Common.Abstractions.Exceptions
{
    public class CustomApplicationException(string message, HttpStatusCode statusCode, IEnumerable<string> errors = null) : Exception(message)
    {
        public HttpStatusCode StatusCode { get; set; } = statusCode;
        public IEnumerable<string> Errors { get; set; } = errors ?? [];
    }
}
