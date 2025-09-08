using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Common.Abstractions.Queries
{
    public interface IQueryBus
    {
        Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
    }
}
