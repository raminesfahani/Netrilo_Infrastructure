using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common.Bus.MessageBrokers
{
    public static class MessageBrokersExtensions
    {
        private static MessageBrokersOptions ConfigureOptions(IServiceCollection services, IConfiguration Configuration)
        {
            var options = new MessageBrokersOptions();
            Configuration.GetSection(nameof(MessageBrokersOptions)).Bind(options);
            services.Configure<MessageBrokersOptions>(Configuration.GetSection(nameof(MessageBrokersOptions)));
            return options;
        }

        private static IServiceCollection RegisterMassTransitLayer(
            this IServiceCollection services,
            MessageBrokersOptions options,
            Type[] consumers,
            Action<IBusRegistrationConfigurator> busRegistrationConfigurator = null,
            Action<IBusRegistrationContext, IServiceBusBusFactoryConfigurator> azureBusFactoryConfigurator = null,
            Action<IBusRegistrationContext, IRabbitMqBusFactoryConfigurator> rabbitMqBusFactoryConfigurator = null
            )
        {
            services
                .AddMassTransit(x =>
                {
                    x.AddConsumers(consumers);
                    x.SetKebabCaseEndpointNameFormatter();

                    busRegistrationConfigurator?.Invoke(x);

                    switch (options.MessageBrokerType)
                    {
                        case MessageBrokerType.AzureServiceBus:
                            {
                                x.UsingAzureServiceBus((ctx, cfg) =>
                                {
                                    cfg.UseMessageRetry(r =>
                                    {
                                        r.Incremental(options.RetryCount, TimeSpan.FromSeconds(options.IntervalCount), TimeSpan.FromSeconds(2));
                                    });

                                    cfg.Host(options.Host);

                                    cfg.ConfigureEndpoints(ctx);

                                    azureBusFactoryConfigurator?.Invoke(ctx, cfg);
                                });
                                break;
                            }
                        case MessageBrokerType.RabbitMq:
                            {
                                x.UsingRabbitMq((ctx, cfg) =>
                                {
                                    cfg.UseMessageRetry(r =>
                                    {
                                        r.Incremental(options.RetryCount, TimeSpan.FromSeconds(options.IntervalCount), TimeSpan.FromSeconds(2));
                                    });

                                    cfg.Host(options.Host, options.Port, options.VirtualHost, c =>
                                    {
                                        c.Username(options.Username);
                                        c.Password(options.Password);
                                    });

                                    cfg.ConfigureEndpoints(ctx);

                                    rabbitMqBusFactoryConfigurator?.Invoke(ctx, cfg);
                                });
                                break;
                            }
                        case MessageBrokerType.Kafka:
                            throw new ArgumentException("Not implemented broker type!");
                        //break;
                        default:
                            throw new ArgumentException("Not supported broker type!");
                            //break;
                    }
                })
                .AddScoped<IEventListener, EventListener>();

            return services;
        }


        /// <summary>
        /// Register MassTransit with general configurations based on options
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        /// <param name="consumers"></param>
        /// <param name="busRegistrationConfigurator"></param>
        /// <returns></returns>
        public static IServiceCollection AddMessageBroker(
            this IServiceCollection services,
            IConfiguration Configuration,
            Type[] consumers,
            Action<IBusRegistrationConfigurator> busRegistrationConfigurator = null
            )
        {
            MessageBrokersOptions options = ConfigureOptions(services, Configuration);

            services.RegisterMassTransitLayer(options, consumers, busRegistrationConfigurator);

            return services;
        }

        /// <summary>
        /// Register MassTransit with custom Azure Service Bus configurations
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        /// <param name="consumers"></param>
        /// <param name="busRegistrationConfigurator"></param>
        /// <param name="azureBusFactoryConfigurator"></param>
        /// <returns></returns>
        public static IServiceCollection AddMessageBroker(
            this IServiceCollection services,
            IConfiguration Configuration,
            Type[] consumers,
            Action<IBusRegistrationConfigurator> busRegistrationConfigurator = null,
            Action<IBusRegistrationContext, IServiceBusBusFactoryConfigurator> azureBusFactoryConfigurator = null
            )
        {
            MessageBrokersOptions options = ConfigureOptions(services, Configuration);

            services.RegisterMassTransitLayer(options, consumers, busRegistrationConfigurator, azureBusFactoryConfigurator);

            return services;
        }

        /// <summary>
        /// Register MassTransit with custom RabbitMq service bus configurations
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        /// <param name="consumers"></param>
        /// <param name="busRegistrationConfigurator"></param>
        /// <param name="rabbitMqBusFactoryConfigurator"></param>
        /// <returns></returns>
        public static IServiceCollection AddMessageBroker(
            this IServiceCollection services,
            IConfiguration Configuration,
            Type[] consumers,
            Action<IBusRegistrationConfigurator> busRegistrationConfigurator = null,
            Action<IBusRegistrationContext, IRabbitMqBusFactoryConfigurator> rabbitMqBusFactoryConfigurator = null
            )
        {
            MessageBrokersOptions options = ConfigureOptions(services, Configuration);

            services.RegisterMassTransitLayer(options, consumers, busRegistrationConfigurator, default, rabbitMqBusFactoryConfigurator);

            return services;
        }

    }
}
