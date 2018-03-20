using LightFrame.Messaging;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace LightFrame.RabbitMq.Handlers
{
    internal static class HandlerConfiguratorExtensions
    {
        public static void ConfigureHandlersAsConsumers(this IReceiveEndpointConfigurator eCfg, IServiceProvider svc)
        {
            var scopeFactory = svc.GetRequiredService<IServiceScopeFactory>();

            var allHandlers = svc.GetServices<IHandler>();
            foreach (var handler in allHandlers)
            {
                var messageType = GetMessageType(handler);

                var handlerConfigurator = HandlerConfiguratorFactory.GetConfigurator(messageType);
                handlerConfigurator.Configure(eCfg, scopeFactory, null);
            }
        }

        private static Type GetMessageType(IHandler handler)
        {
            return handler
                .GetType()
                .GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IHandler<>))
                .SelectMany(i => i.GenericTypeArguments)
                .Single();
        }
    }
}
