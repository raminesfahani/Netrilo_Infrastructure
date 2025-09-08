using MassTransit;

namespace Infrastructure.Common.Bus.Bus
{
    public interface IEventBus
    {
        Task Publish<TEvent>(params TEvent[] events);
        Task PublishLocal(params Event[] events);
    }
}
