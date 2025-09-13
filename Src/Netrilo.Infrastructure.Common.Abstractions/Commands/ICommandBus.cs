using System.Threading;
using System.Threading.Tasks;

namespace Netrilo.Infrastructure.Common.Abstractions.Commands
{
    public interface ICommandBus
    {
        Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);

        Task Send(ICommand command, CancellationToken cancellationToken = default);
    }
}
