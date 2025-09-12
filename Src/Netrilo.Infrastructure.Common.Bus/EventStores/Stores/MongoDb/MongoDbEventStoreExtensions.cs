using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Common.Bus.EventStores;
using Infrastructure.Common.Bus.EventStores.Stores;

namespace Infrastructure.Common.Bus.EventStores.Stores.MongoDb
{
    public static class MongoDbEventStoreExtensions
    {
        public static IServiceCollection AddMongoDbEventStore(this IServiceCollection services, IConfiguration Configuration)
        {
            var options = new MongoDbEventStoreOptions();
            Configuration.GetSection(nameof(EventStoresOptions)).Bind(options);
            services.Configure<MongoDbEventStoreOptions>(Configuration.GetSection(nameof(EventStoresOptions)));

            services.AddScoped<IStore, MongoDbEventStore>();

            return services;
        }
    }
}
