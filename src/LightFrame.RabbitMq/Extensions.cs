using LightFrame.Messaging;
using LightFrame.RabbitMq.Handlers;
using LightFrame.RabbitMq.Publishers;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LightFrame.RabbitMq
{
    public static class Extensions
    {
        public static IServiceCollection AddServiceBus(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<Settings>(config);

            services.AddTransient<IPublisher, Publisher>();
            services.AddScoped<IOutbox, Outbox>();

            services.AddSingleton(svc =>
            {
                var settings = svc.GetRequiredService<IOptions<Settings>>().Value;

                var hostAddress = settings.ServiceBus.Host;
                var username = settings.ServiceBus.Username;
                var password = settings.ServiceBus.Password;
                var applicationName = settings.Application.Name;

                return BusFactory.Create(applicationName, hostAddress, username, password, eCfg => eCfg.ConfigureHandlersAsConsumers(svc));
            });
            services.AddSingleton<IBus>(svc => svc.GetRequiredService<IBusControl>());

            return services;
        }

        public static void UseServiceBus(this IApplicationBuilder app, IApplicationLifetime lifetime)
        {
            var bus = app.ApplicationServices.GetRequiredService<IBusControl>();

            lifetime.ApplicationStarted.Register(() => bus.Start());
            lifetime.ApplicationStopping.Register(() => bus.Stop());
        }
    }
}
