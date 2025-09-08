using System.Text.Json.Serialization;

namespace Infrastructure.Common.Abstractions.Dto
{
    [Serializable]
    public class BaseExceptionResponse(string title, string traceId, int status, IEnumerable<string> errors = null)
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = title;

        [JsonPropertyName("errors")]
        public IEnumerable<string> Errors { get; set; } = errors;

        [JsonPropertyName("traceId")]
        public string TraceId { get; set; } = traceId;

        [JsonPropertyName("status")]
        public int Status { get; set; } = status;
    }
}
