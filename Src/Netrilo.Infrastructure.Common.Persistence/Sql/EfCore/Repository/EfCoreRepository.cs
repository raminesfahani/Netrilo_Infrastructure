using Microsoft.EntityFrameworkCore;
//using MongoDB.Driver.Linq;
using System.Linq.Expressions;
using Netrilo.Infrastructure.Common.Abstractions.Abstracts;
using Netrilo.Infrastructure.Common.Abstractions.Dto;

namespace Netrilo.Infrastructure.Common.Persistence.Sql.EfCore.Repository
{
    public abstract class EfCoreRepository<TEntity, TContext, TKey>(TContext context) : IEfCoreRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TContext : BaseDbContext
    {
        private readonly TContext context = context;

        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(TKey id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(TKey id, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = context.Set<TEntity>().AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.FirstOrDefaultAsync(x => x.Id.ToString().ToLower() == id.ToString().ToLower());
        }

        public async Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = context.Set<TEntity>().AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (predicate is not null)
                query = query.Where(predicate);

            return await Task.FromResult(query);
        }

        public async Task<PaginatedListDto<TEntity>> GetPaginatedList(Expression<Func<TEntity, bool>> predicate, int pageNumber = 1, int pageSize = 20, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = context.Set<TEntity>().AsNoTracking();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            query = query.Where(predicate);

            var paginatedList = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            PaginatedListDto<TEntity> result = new(paginatedList, query.Count(), pageNumber, pageSize);
            return await Task.FromResult(result);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
