using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using Netrilo.Infrastructure.Common.Web.ServiceDiscovery.Consul;

namespace Netrilo.Infrastructure.Common.Web.ServiceDiscovery.ApplicationInsight
{
    public static class ApplicationInsightExtensions
    {
        public static IServiceCollection AddApplicationInsight(this IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry();
            return services;
        }
    }
}
