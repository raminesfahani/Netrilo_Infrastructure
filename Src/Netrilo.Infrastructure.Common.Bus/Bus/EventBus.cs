using MassTransit;
using MediatR;
using Netrilo.Infrastructure.Common.Bus.MessageBrokers;

namespace Netrilo.Infrastructure.Common.Bus.Bus
{
    public class EventBus(
        IMediator mediator,
        IPublishEndpoint publishEndpoint) : IEventBus
    {
        private readonly IMediator _mediator = mediator ?? throw new Exception($"Missing dependency '{nameof(IMediator)}'");
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint ?? throw new Exception($"Missing dependency '{nameof(IPublishEndpoint)}'");

        public virtual async Task PublishLocal(params Event[] events)
        {
            foreach (var @event in events)
            {
                await _mediator.Publish(@event);
            }
        }

        public virtual async Task Publish<TEvent>(params TEvent[] events)
        {
            foreach (var @event in events)
            {
                await _publishEndpoint.Publish(@event);
            }
        }
    }
}
