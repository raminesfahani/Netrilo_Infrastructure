using Infrastructure.Common.Abstractions.Events;

namespace Infrastructure.Common.Bus.EventStores.Projection
{
    public interface IProjection
    {
        Type[] Handles { get; }
        void Handle(IEvent @event);
    }
}
