using MediatR;

namespace Infrastructure.Common.Abstractions.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    { }
}
