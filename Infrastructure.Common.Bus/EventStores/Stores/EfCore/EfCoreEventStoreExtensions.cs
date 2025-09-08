using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common.Bus.EventStores.Stores.EfCore
{
    public static class EfCoreEventStoreExtensions
    {
        public static IServiceCollection AddEfCoreEventStore(this IServiceCollection services, Action<DbContextOptionsBuilder> dbContextOptions)
        {
            services.AddDbContext<EfCoreEventStoreContext>(dbContextOptions);
            services.AddScoped<IStore, EfCoreEventStore>();

            return services;
        }
    }
}
