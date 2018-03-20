using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LightFrame.RabbitMq.Handlers
{
    interface IHandlerConfigurator
    {
        void Configure(IReceiveEndpointConfigurator eCfg, IServiceScopeFactory scopeFactory, IEnumerable<Func<ConsumeContext, IServiceProvider, Func<Task>, Task>> middleware);
    }
}
