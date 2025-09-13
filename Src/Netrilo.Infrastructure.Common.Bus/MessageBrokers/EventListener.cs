using System.Threading.Tasks;
using MassTransit;
using System.Threading;
using MassTransit.Transports;
using Microsoft.Extensions.DependencyInjection;

namespace Netrilo.Infrastructure.Common.Bus.MessageBrokers
{
    public class EventListener(IPublishEndpoint publishEndpoint) : IEventListener
    {
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
        public async Task Publish<TEvent>(
            TEvent @event)
        {
            await _publishEndpoint.Publish(@event);
        }
    }
}
