using Autofac;
using LightFrame.Core.Settings;
using LightFrame.RabbitMq.Settings;
using MassTransit;
using Serilog;
using System;
using System.Diagnostics;

namespace LightFrame.RabbitMq
{
    internal static class BusConfigurator
    {
        public static IBusControl Default(IComponentContext ctx, GeneralSettings generalSettings, BusSettings busSettings)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(busSettings.Host), hCfg =>
                {
                    hCfg.Username(busSettings.Username);
                    hCfg.Password(busSettings.Password);
                    hCfg.Heartbeat((ushort)(Debugger.IsAttached ? 0 : 5));
                });

                cfg.UseJsonSerializer();

                var logger = ctx.Resolve<ILogger>().ForContext("Framework", "Bus");
                cfg.UseSerilog(logger);

                cfg.ReceiveEndpoint(host, generalSettings.Name, epCfg =>
                {
                });
            });
        }
    }
}
