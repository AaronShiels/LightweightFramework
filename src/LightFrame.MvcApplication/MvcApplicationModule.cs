using Autofac;
using LightFrame.Logging;
using LightFrame.MvcApplication.Filters;

namespace LightFrame.MvcApplication
{
    public class MvcApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<LoggingModule>();

            builder.RegisterType<HookActionFilter>();
        }
    }
}
