using MediatR;

namespace Netrilo.Infrastructure.Common.Abstractions.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    { }
}
