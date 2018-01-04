using Autofac;
using LightFrame.Core;
using LightFrame.Logging;
using LightFrame.MvcApplication;
using LightFrame.Sample.Core;
using LightFrame.Sample.Middleware;
using Microsoft.AspNetCore.Hosting;

namespace LightFrame.Sample
{
    public class Startup : MvcStartUp
    {
        public Startup(IHostingEnvironment env) : base(env)
        {
        }

        public override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterInstance(Configuration)
                .AsImplementedInterfaces();

            builder.RegisterModule<CoreModule>();
            builder.RegisterModule<LoggingModule>();

            builder.RegisterType<MiddlewareA>()
                .AsImplementedInterfaces();
            builder.RegisterType<MiddlewareB>()
                .AsImplementedInterfaces();
            builder.RegisterType<MiddlewareC>()
                .AsImplementedInterfaces();

            builder.RegisterType<RandomValueFactory>()
                .AsImplementedInterfaces();
        }
    }
}
