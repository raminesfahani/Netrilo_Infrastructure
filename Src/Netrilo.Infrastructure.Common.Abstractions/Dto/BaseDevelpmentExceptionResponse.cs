using System.Text.Json.Serialization;

namespace Infrastructure.Common.Abstractions.Dto
{
    [Serializable]
    public class BaseDevelpmentExceptionResponse(string title,
                                                 string traceId,
                                                 int status,
                                                 Exception exception,
                                                 IEnumerable<string> errors = null) : BaseExceptionResponse(title, traceId, status, errors)
    {
        [JsonPropertyName("dev_details")]
        public Exception Exception { get; set; } = exception;
    }
}
