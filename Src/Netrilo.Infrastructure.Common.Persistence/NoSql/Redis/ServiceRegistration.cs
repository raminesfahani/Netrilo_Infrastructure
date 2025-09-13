using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Netrilo.Infrastructure.Common.Persistence.NoSql.Redis.Repository;

namespace Infrastructure.Databases.Redis
{
    public static partial class ServiceRegistration
    {
        public static IServiceCollection AddRedisDb(this IServiceCollection services, IConfiguration configuration)
        {
            RedisSettings settings = new();
            configuration.GetSection(RedisConstants.ConfigurationKey).Bind(settings);
            services.Configure<RedisSettings>(configuration.GetSection(RedisConstants.ConfigurationKey));

            services.AddSingleton<IRedisSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<RedisSettings>>().Value);

            services.AddScoped<IRedisRepository, RedisRepository>();

            services.AddStackExchangeRedisCache(action => {
                 action.Configuration = settings.ConnectionString;
             });

            return services;
        }
    }
}
