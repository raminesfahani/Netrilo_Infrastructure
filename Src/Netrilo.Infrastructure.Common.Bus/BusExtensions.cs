using Infrastructure.Common.Bus.Bus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Infrastructure.Common.Abstractions.Commands;
using Infrastructure.Common.Abstractions.Queries;
using Infrastructure.Common.Abstractions;

namespace Infrastructure.Common.Bus
{
    public static class BusExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services, params Type[] types)
        {
            var assemblies = types.Select(type => type.GetTypeInfo().Assembly);

            services.AddMediatR(x => x.RegisterServicesFromAssemblies([.. assemblies]));

            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<IQueryBus, QueryBus>();

            services.AddScoped<IEventBus, EventBus>();

            services.AddMappingProfiles();

            return services;
        }
    }
}
