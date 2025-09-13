using Netrilo.Infrastructure.Common.Abstractions.Events;

namespace Netrilo.Infrastructure.Common.Bus.EventStores.Projection
{
    public abstract class Projection : IProjection
    {
        private readonly Dictionary<Type, Action<IEvent>> Handlers = new Dictionary<Type, Action<IEvent>>();

        public Type[] Handles => Handlers.Keys.ToArray();

        protected virtual void Projects<TEvent>(Action<IEvent> action)
        {
            Handlers.Add(typeof(IEvent), @event => action(@event));
        }

        public virtual void Handle(IEvent @event)
        {
            Handlers[@event.GetType()](@event);
        }
    }
}
