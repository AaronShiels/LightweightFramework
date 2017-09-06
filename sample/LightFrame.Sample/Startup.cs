using Autofac;
using LightFrame.MvcApplication;
using LightFrame.Sample.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace LightFrame.Sample
{
    public class Startup : MvcStartUp
    {
        public Startup(IHostingEnvironment env) : base(env)
        {
        }

        public override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<MvcApplicationModule>();

            builder.RegisterType<RandomValueFactory>()
                .AsImplementedInterfaces();

            builder.Register(cc =>
            {
                var settings = new ApplicationSettings();
                Configuration.GetSection("Application").Bind(settings);
                return settings;
            });
        }
    }
}
