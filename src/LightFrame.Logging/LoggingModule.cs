using Autofac;
using LightFrame.Core;
using LightFrame.Core.Settings;
using LightFrame.Logging.Hooks;
using LightFrame.Logging.Settings;

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
                    var generalSettings = ctx.Resolve<GeneralSettings>();
                    var loggingSettings = ctx.Resolve<LoggingSettings>();
                    return LoggerConfigurator.Default(generalSettings, loggingSettings);
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
