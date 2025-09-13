using Netrilo.Infrastructure.Common.Abstractions.Events;

namespace Netrilo.Infrastructure.Common.Bus.EventStores.Aggregate
{
    public abstract class Aggregate : IAggregate
    {
        public Guid Id { get; protected set; }
        public int Version { get; protected set; } = 0;
        public DateTime CreatedUtc { get; protected set; }
        public virtual string Name => "";

        [NonSerialized]
        private readonly List<IEvent> uncommittedEvents = [];

        protected Aggregate()
        { }

        IEnumerable<IEvent> IAggregate.DequeueUncommittedEvents()
        {
            var dequeuedEvents = uncommittedEvents.ToList();

            uncommittedEvents.Clear();

            return dequeuedEvents;
        }

        protected virtual void Enqueue(IEvent @event)
        {
            Version++;
            CreatedUtc = DateTime.UtcNow;
            uncommittedEvents.Add(@event);
        }
    }
}
