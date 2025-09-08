using StackExchange.Redis;
using System;
using static Infrastructure.Databases.Redis.ServiceRegistration;

namespace Infrastructure.Common.Persistence.NoSql.Redis
{
    public static class ConnectionHelper
    {
        private static readonly Lazy<Func<IRedisSettings, ConnectionMultiplexer>> lazyConnection = new(setting =>
        {
            return ConnectionMultiplexer.Connect(setting.ConnectionString);
        });

        public static ConnectionMultiplexer Connection(IRedisSettings redisSettings)
        {
            return lazyConnection.Value(redisSettings);
        }
    }
}
