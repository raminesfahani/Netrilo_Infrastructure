using Infrastructure.Common.Abstractions.Events;

namespace Infrastructure.Common.Bus.EventStores.Aggregate
{
    public interface IAggregate
    {
        Guid Id { get; }
        int Version { get; }
        DateTime CreatedUtc { get; }

        IEnumerable<IEvent> DequeueUncommittedEvents();

    }
}
