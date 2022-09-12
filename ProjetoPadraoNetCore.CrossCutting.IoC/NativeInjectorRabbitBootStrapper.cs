using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nascorp.Library.MQ.Rabbit;
using ProjetoPadraoNetCore.Domain.Events;
using ProjetoPadraoNetCore.RabbitMQ;
using RabbitMQ.Client;

namespace ProjetoPadraoNetCore.CrossCutting.IoC
{
    public class NativeInjectorRabbitBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // RABBIT
            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = configuration["EventBusConnection"]
                };

                if (!string.IsNullOrEmpty(configuration["EventBusUserName"]))
                {
                    factory.UserName = configuration["EventBusUserName"];
                }

                if (!string.IsNullOrEmpty(configuration["EventBusPassword"]))
                {
                    factory.Password = configuration["EventBusPassword"];
                }

                if (!string.IsNullOrEmpty(configuration["VirtualHost"]))
                {
                    factory.VirtualHost = configuration["VirtualHost"];
                }

                var retryCount = 5;
                if (!string.IsNullOrEmpty(configuration["EventBusRetryCount"]))
                    retryCount = int.Parse(configuration["EventBusRetryCount"]);

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            });
        }

        public static void RegisterBusServices(IServiceCollection services, IConfiguration configuration)
        {
            var subscriptionClientName = configuration["SubscriptionClientName"];
            services.AddSingleton<IEventBusRabbitMQ, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();
                int.TryParse(configuration["EventBusRetryCount"], out int retryCount);

                string brokerName = configuration["BrokerName"];
                string autofacScopeName = configuration["AutofacScopeName"];
                return new EventBusRabbitMQ(rabbitMQPersistentConnection
                                            , logger
                                            , iLifetimeScope
                                            , eventBusSubcriptionsManager
                                            , brokerName
                                            , autofacScopeName
                                            , subscriptionClientName
                                            , retryCount);
            });

            services.AddTransient<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
            services.AddSingleton<MyServiceEventHandler>();
        }

        public static void ConfigureBusServices(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBusRabbitMQ>();
            eventBus.Subscribe<MyServiceIntegrationEvent, MyServiceEventHandler>();
        }
    }
}
