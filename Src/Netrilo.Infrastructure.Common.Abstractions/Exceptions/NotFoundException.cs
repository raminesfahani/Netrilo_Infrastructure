namespace Netrilo.Infrastructure.Common.Abstractions.Exceptions
{
    public class NotFoundException(string message) : Exception(message)
    {
    }
}
