using System;
using Infrastructure.Common.Bus.EventStores.Aggregate;

namespace Infrastructure.Common.Bus.EventStores.Snapshot
{
    public interface ISnapshot
    {
        Type Handles { get; }
        void Handle(IAggregate aggregate);
    }
}
