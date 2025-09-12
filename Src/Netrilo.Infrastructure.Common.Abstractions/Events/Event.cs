using System;

namespace Infrastructure.Common.Abstractions.Events
{
    public abstract class Event : IEvent
    {
        public virtual Guid Id { get; } = Guid.NewGuid();
        public virtual DateTime CreatedUtc { get; } = DateTime.UtcNow;
    }
}
