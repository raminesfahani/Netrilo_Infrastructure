using MassTransit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Common.Bus.MessageBrokers
{
    public interface IEventListener
    {
        Task Publish<TEvent>(TEvent @event);
    }
}
