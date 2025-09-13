using System;
using Netrilo.Infrastructure.Common.Bus.EventStores.Aggregate;

namespace Netrilo.Infrastructure.Common.Bus.EventStores.Snapshot
{
    public interface ISnapshot
    {
        Type Handles { get; }
        void Handle(IAggregate aggregate);
    }
}
