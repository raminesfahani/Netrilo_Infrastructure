namespace Infrastructure.Common.Persistence.NoSql.MongoDB.Settings
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
