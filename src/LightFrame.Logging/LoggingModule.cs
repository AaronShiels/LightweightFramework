using Autofac;
using LightFrame.Core;
using LightFrame.Logging.Hooks;

namespace LightFrame.Logging
{
    public class LoggingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSetting<LoggingSettings>("Logging");

            builder
                .Register(ctx =>
                {
                    var settings = ctx.Resolve<LoggingSettings>();
                    return LoggerConfigurator.Default(settings);
                })
                .AsImplementedInterfaces()
                .SingleInstance();

            builder
                .RegisterType<LoggingMiddleware>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
