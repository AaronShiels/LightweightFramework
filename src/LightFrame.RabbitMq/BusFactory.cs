using MassTransit;
using System;
using System.Diagnostics;

namespace LightFrame.RabbitMq
{
    internal static class BusFactory
    {
        public static IBusControl Create(string applicationName, string hostAddress, string username, string password, Action<IReceiveEndpointConfigurator> consumerConfiguration)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var hostUri = new Uri($"rabbitmq://{hostAddress}");
                var host = cfg.Host(hostUri, hCfg =>
                {
                    hCfg.Heartbeat((ushort)(Debugger.IsAttached ? 0 : 5));
                    hCfg.Username(username ?? "guest");
                    hCfg.Password(password ?? "guest");
                });

                cfg.ReceiveEndpoint(host, applicationName, consumerConfiguration);
            });
        }
    }
}
