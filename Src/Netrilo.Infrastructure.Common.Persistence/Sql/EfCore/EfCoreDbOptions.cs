namespace Netrilo.Infrastructure.Common.Persistence.Sql.EfCore
{
    public class EfCoreDbOptions
    {
        public string DatabaseType { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
    }
}
