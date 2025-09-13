using MediatR;

namespace Netrilo.Infrastructure.Common.Abstractions.Events
{
    public interface IEventHandler<T> : INotificationHandler<T> where T : IEvent
    { }
}
