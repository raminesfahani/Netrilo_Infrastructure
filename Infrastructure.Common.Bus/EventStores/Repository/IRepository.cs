using Infrastructure.Common.Bus.EventStores.Aggregate;

namespace Infrastructure.Common.Bus.EventStores.Repository
{
    public interface IRepository<TAggregate> where TAggregate : IAggregate
    {
        Task<TAggregate> Find(Guid id);
        Task<ICollection<TAggregate>> Find(ICollection<Guid> id);
        Task Add(TAggregate aggregate);
        Task Add(ICollection<TAggregate> aggregates);
        Task Update(TAggregate aggregate);
        Task Update(ICollection<TAggregate> aggregates);
        Task Delete(TAggregate aggregate);
        Task Delete(ICollection<TAggregate> aggregates);
    }
}
