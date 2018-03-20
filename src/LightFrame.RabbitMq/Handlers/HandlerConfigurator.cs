using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LightFrame.Messaging;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace LightFrame.RabbitMq.Handlers
{
    internal class HandlerConfigurator<TMessage> : IHandlerConfigurator where TMessage : class
    {
        public void Configure(IReceiveEndpointConfigurator eCfg, IServiceScopeFactory scopeFactory, IEnumerable<Func<ConsumeContext, IServiceProvider, Func<Task>, Task>> middleware)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var svc = scope.ServiceProvider;
                var handler = svc.GetRequiredService<IHandler<TMessage>>();
                eCfg.Handler<TMessage>(async (context) =>
                {
                    await handler.Handle(context.Message);
                });
            }
        }
    }
}
