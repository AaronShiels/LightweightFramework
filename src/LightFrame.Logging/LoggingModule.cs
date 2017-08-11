using Autofac;
using LightFrame.Logging.Hooks;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace LightFrame.Logging
{
    public class LoggingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(ctx =>
                {
                    var settings = new Settings();
                    ctx.Resolve<IConfiguration>().Bind(settings);

                    return settings;
                })
                .SingleInstance();

            builder
                .RegisterInstance(Log.Logger)
                .AsImplementedInterfaces()
                .SingleInstance();

            builder
                .RegisterType<LoggingHook>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
