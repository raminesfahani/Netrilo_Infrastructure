using Netrilo.Infrastructure.Common.Abstractions.Events;
using Netrilo.Infrastructure.Common.Bus.EventStores.Aggregate;
using Netrilo.Infrastructure.Common.Bus.EventStores.Projection;
using Netrilo.Infrastructure.Common.Bus.EventStores.Snapshot;

namespace Netrilo.Infrastructure.Common.Bus.EventStores
{
    public interface IEventStore
    {
        void AddSnapshot(ISnapshot snapshot);

        void AddProjection(IProjection projection);

        Task AppendEvent<TAggregate>(Guid aggregateId, IEvent @event, int? expectedVersion = null, Func<StreamState, Task> action = null) where TAggregate : IAggregate;

        Task<TAggregate> AggregateStream<TAggregate>(Guid aggregateId, int? version = null, DateTime? createdUtc = null) where TAggregate : IAggregate;
        Task<ICollection<TAggregate>> AggregateStream<TAggregate>(ICollection<Guid> ids) where TAggregate : IAggregate;

        Task<IEnumerable<StreamState>> GetEvents(Guid aggregateId, int? version = null, DateTime? createdUtc = null);

        Task Store<TAggregate>(TAggregate aggregate, Func<StreamState, Task> action = null) where TAggregate : IAggregate;
        Task Store<TAggregate>(ICollection<TAggregate> aggregates, Func<StreamState, Task> action = null) where TAggregate : IAggregate;
    }
}
