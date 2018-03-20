using System;

namespace LightFrame.RabbitMq.Handlers
{
    internal static class HandlerConfiguratorFactory
    {
        public static IHandlerConfigurator GetConfigurator(Type messageType)
        {
            return (IHandlerConfigurator)Activator.CreateInstance(typeof(HandlerConfigurator<>).MakeGenericType(messageType));
        }
    }
}
