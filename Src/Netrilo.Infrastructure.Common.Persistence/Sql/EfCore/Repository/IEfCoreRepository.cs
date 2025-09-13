using System.Linq.Expressions;
using Netrilo.Infrastructure.Common.Abstractions.Abstracts;
using Netrilo.Infrastructure.Common.Abstractions.Dto;

namespace Netrilo.Infrastructure.Common.Persistence.Sql.EfCore.Repository
{
    public interface IEfCoreRepository<T, TKey> where T : BaseEntity<TKey>
    {
        Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<PaginatedListDto<T>> GetPaginatedList(Expression<Func<T, bool>> predicate, int pageNumber = 1, int pageSize = 20, params Expression<Func<T, object>>[] includes);
        Task<T> Get(TKey id, params Expression<Func<T, object>>[] includes);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(TKey id);
    }
}
