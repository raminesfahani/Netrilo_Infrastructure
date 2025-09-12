namespace Infrastructure.Databases.Redis
{
    public static partial class ServiceRegistration
    {
        public class RedisSettings : IRedisSettings
        {
            public string ConnectionString { get; set; }
        }
    }
}
