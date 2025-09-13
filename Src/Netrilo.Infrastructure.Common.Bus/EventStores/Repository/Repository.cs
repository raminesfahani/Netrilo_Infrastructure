using Netrilo.Infrastructure.Common.Bus.Bus;
using Netrilo.Infrastructure.Common.Bus.EventStores;
using Netrilo.Infrastructure.Common.Bus.EventStores.Aggregate;

namespace Netrilo.Infrastructure.Common.Bus.EventStores.Repository
{
    public class Repository<TAggregate>(IEventStore eventStore, IEventBus eventBus) : IRepository<TAggregate> where TAggregate : IAggregate
    {
        private readonly IEventStore _eventStore = eventStore;
        private readonly IEventBus _eventBus = eventBus;

        public virtual async Task Add(TAggregate aggregate)
        {
            await _eventStore.Store(aggregate, PublishEvent);
        }

        public virtual async Task Add(ICollection<TAggregate> aggregates)
        {
            await _eventStore.Store(aggregates, PublishEvent);
        }

        public virtual async Task Delete(TAggregate aggregate)
        {
            await _eventStore.Store(aggregate, PublishEvent);
        }

        public virtual async Task Delete(ICollection<TAggregate> aggregates)
        {
            await _eventStore.Store(aggregates, PublishEvent);
        }

        public virtual async Task<TAggregate> Find(Guid id)
        {
            var result = await _eventStore.AggregateStream<TAggregate>(id);

            return result;
        }

        public virtual async Task<ICollection<TAggregate>> Find(ICollection<Guid> ids)
        {
            var result = await _eventStore.AggregateStream<TAggregate>(ids);

            return result;
        }

        public virtual async Task Update(TAggregate aggregate)
        {
            await _eventStore.Store(aggregate, PublishEvent);
        }

        public virtual async Task Update(ICollection<TAggregate> aggregates)
        {
            await _eventStore.Store(aggregates, PublishEvent);
        }

        private async Task PublishEvent(StreamState stream)
        {
            if (stream is null)
            {
                throw new Exception($"{nameof(stream)} was null");
            }

            // Not implemented
        }
    }
}
