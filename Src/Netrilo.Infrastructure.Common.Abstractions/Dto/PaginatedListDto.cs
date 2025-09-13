using Microsoft.EntityFrameworkCore;

namespace Netrilo.Infrastructure.Common.Abstractions.Dto
{
    public class PaginatedListDto<T>(IReadOnlyCollection<T> items, int count, int pageNumber, int pageSize)
    {
        public IReadOnlyCollection<T> Items { get; } = items;
        public int PageNumber { get; } = pageNumber;
        public int TotalPages { get; } = (int)Math.Ceiling(count / (double)pageSize);
        public int TotalCount { get; } = count;

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;

        public static async Task<PaginatedListDto<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedListDto<T>(items, count, pageNumber, pageSize);
        }
    }

}
