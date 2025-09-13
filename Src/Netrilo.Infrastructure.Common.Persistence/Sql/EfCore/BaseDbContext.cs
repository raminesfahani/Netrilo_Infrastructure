using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Netrilo.Infrastructure.Common.Persistence.Sql.EfCore
{
    public class BaseDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                throw new ArgumentException("DB options are'nt configured completely!");
            }
            //builder.AddInterceptors();
            base.OnConfiguring(builder);
        }
    }
}
