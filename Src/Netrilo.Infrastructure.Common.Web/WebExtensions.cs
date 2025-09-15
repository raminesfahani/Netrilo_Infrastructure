using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Netrilo.Infrastructure.Common.Abstractions;
using Netrilo.Infrastructure.Common.Web.ApiExplorer.Swagger;
using Netrilo.Infrastructure.Common.Web.ServiceDiscovery.ApplicationInsight;
using Netrilo.Infrastructure.Common.Web.ServiceDiscovery.Consul;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Netrilo.Infrastructure.Common.Web
{
    public static class WebExtensions
    {
        public static IServiceCollection AddCommonWeb(this IServiceCollection services, IConfiguration configuration, params Type[] validatorTypes)
        {
            var assemblies = validatorTypes.Select(type => type.GetTypeInfo().Assembly);

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

            services.AddSwagger(configuration);

            services.AddValidatorsFromAssemblies(assemblies);
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddMappingProfiles();
            services.AddApplicationInsight();

            return services;
        }

        /// <summary>
        /// Applies all common web middlewares (Swagger, Consul, etc.)
        /// </summary>
        /// <param name="app">The application builder</param>
        /// <param name="configuration">Application configuration</param>
        /// <returns>The same application builder for chaining</returns>
        public static IApplicationBuilder UseCommonWeb(this IApplicationBuilder app, IConfiguration configuration, IHostApplicationLifetime hostApplicationLifetime)
        {
            // Apply Swagger UI and OpenAPI
            app.UseSwagger(configuration);

            // Apply Consul service registration and health checks
            app.UseConsul(hostApplicationLifetime);

            // (Optional) If you have more middleware in the future (CORS, Telemetry, etc.)
            // add them here in a unified manner.

            return app;
        }
    }
}
