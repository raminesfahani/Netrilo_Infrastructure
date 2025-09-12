using Infrastructure.Common.Persistence.Sql.EfCore.Interceptors;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Common.Persistence.Sql.EfCore
{
    public static class EfCoreExtension
    {
        public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
            entry.References.Any(r =>
                r.TargetEntry != null &&
                r.TargetEntry.Metadata.IsOwned() &&
                (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));

        public static IServiceCollection AddEfCore<TContext>(this IServiceCollection services, IConfiguration configuration) where TContext : BaseDbContext
        {
            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

            //Registerign DbContext based on the selected DB type
            //----------------------------------------------------
            var efCoreOptions = new EfCoreDbOptions();
            configuration.GetSection(nameof(EfCoreDbOptions)).Bind(efCoreOptions);
            services.Configure<EfCoreDbOptions>(configuration.GetSection(nameof(EfCoreDbOptions)));

            services.AddDbContext<TContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                switch (efCoreOptions.DatabaseType.ToLowerInvariant())
                {
                    case "sqlserver":
                        {
                            options.UseSqlServer(efCoreOptions.ConnectionString);
                            break;
                        }
                    case "postgres":
                        {
                            options.UseNpgsql(efCoreOptions.ConnectionString);
                            break;
                        }
                    default:
                        {
                            throw new Exception($"Database type '{efCoreOptions.DatabaseType}' is not supported");
                        }
                };
            });

            //Registering all generic repo types
            //------------------------------------
            Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(a => a.Name.EndsWith("EfCoreRepository") && !a.IsAbstract && !a.IsInterface)
                    .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
                    .ToList()
                    .ForEach(typesToRegister =>
                    {
                        typesToRegister.serviceTypes.ForEach(typeToRegister => services.AddScoped(typeToRegister, typesToRegister.assignedType));
                    });

            return services;
        }

        public static IApplicationBuilder UseEfCore<TContext>(this IApplicationBuilder app) where TContext : BaseDbContext
        {
            UpdateDatabase<TContext>(app);
            return app;
        }

        private static void UpdateDatabase<TContext>(IApplicationBuilder app) where TContext : BaseDbContext
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<TContext>();
            context.Database.Migrate();
        }
    }
}
