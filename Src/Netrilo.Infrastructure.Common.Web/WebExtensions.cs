using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Netrilo.Infrastructure.Common.Web.ServiceDiscovery.ApplicationInsight;
using Netrilo.Infrastructure.Common.Abstractions;

namespace Netrilo.Infrastructure.Common.Web
{
    public static class WebExtensions
    {
        public static IServiceCollection AddCommonWeb(this IServiceCollection services, params Type[] types)
        {
            var assemblies = types.Select(type => type.GetTypeInfo().Assembly);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddOptions();

            services.AddMvc(opt =>
            {
                opt.Filters.Add<ExceptionFilter>();
            });

            services.AddHealthChecks();

            services.AddControllers()
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            services.AddValidatorsFromAssemblies(assemblies);
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddMappingProfiles();
            services.AddApplicationInsight();

            return services;
        }
    }
}
