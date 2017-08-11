using Autofac;
using LightFrame.Logging;

namespace LightFrame.MvcApplication
{
    public class MvcApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new LoggingModule());
        }
    }
}
