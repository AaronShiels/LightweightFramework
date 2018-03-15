using LightFrame.Messaging;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;

namespace LightFrame.RabbitMq
{
    public static class Extensions
    {
        public static IServiceCollection AddServiceBus(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<Settings>(config);

            return services.AddSingleton(svc =>
            {
                var settings = svc.GetService<IOptions<Settings>>().Value;

                return Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var hostUri = new Uri($"rabbitmq://{settings.ServiceBus.Host}");
                    var host = cfg.Host(hostUri, hCfg =>
                    {
                        hCfg.Heartbeat((ushort)(Debugger.IsAttached ? 0 : 5));
                        hCfg.Username(settings.ServiceBus.Username ?? "guest");
                        hCfg.Password(settings.ServiceBus.Password ?? "guest");
                    });

                    var allConsumers = svc.GetServices<IHandler>();
                    cfg.ReceiveEndpoint(host, settings.Application.Name, eCfg =>
                    {
                        throw new NotImplementedException();
                    });
                });
            });
        }

        public static void UseServiceBus(this IApplicationBuilder app, IApplicationLifetime lifetime)
        {
            var bus = app.ApplicationServices.GetService<IBusControl>();

            lifetime.ApplicationStarted.Register(() => bus.Start());
            lifetime.ApplicationStopping.Register(() => bus.Stop());
        }
    }
}
