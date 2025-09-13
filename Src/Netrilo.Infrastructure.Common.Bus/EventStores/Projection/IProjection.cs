using Netrilo.Infrastructure.Common.Abstractions.Events;

namespace Netrilo.Infrastructure.Common.Bus.EventStores.Projection
{
    public interface IProjection
    {
        Type[] Handles { get; }
        void Handle(IEvent @event);
    }
}
