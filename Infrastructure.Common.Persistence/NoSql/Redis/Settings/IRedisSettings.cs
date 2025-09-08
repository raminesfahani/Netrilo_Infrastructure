namespace Infrastructure.Databases.Redis
{
    public static partial class ServiceRegistration
    {
        public interface IRedisSettings
        {
            public string ConnectionString { get; set; }
        }
    }
}
