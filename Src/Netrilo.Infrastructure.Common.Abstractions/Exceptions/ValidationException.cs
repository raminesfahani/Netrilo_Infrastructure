namespace Infrastructure.Common.Abstractions.Exceptions
{
    public class ValidationException(string message) : Exception(message)
    {
        public IEnumerable<string> Errors { get; set; } = [];
    }
}
