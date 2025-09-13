using Netrilo.Infrastructure.Common.Abstractions.Events;

namespace Netrilo.Infrastructure.Common.Bus.EventStores.Aggregate
{
    public interface IAggregate
    {
        Guid Id { get; }
        int Version { get; }
        DateTime CreatedUtc { get; }

        IEnumerable<IEvent> DequeueUncommittedEvents();

    }
}
