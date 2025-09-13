using MediatR;

namespace Netrilo.Infrastructure.Common.Abstractions.Commands
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    { }

    public interface ICommand : IRequest
    { }
}
