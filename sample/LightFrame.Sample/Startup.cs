using Autofac;
using LightFrame.MvcApplication;
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
            builder.RegisterModule(new MvcApplicationModule());
        }
    }
}
