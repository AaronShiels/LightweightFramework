using Autofac;
using Autofac.Builder;
using Microsoft.Extensions.Configuration;

namespace LightFrame.Core
{
    public static class AutofacExtensions
    {
        public static IRegistrationBuilder<TSetting, SimpleActivatorData, SingleRegistrationStyle> RegisterSetting<TSetting>(this ContainerBuilder cb, string configurationSection = null)
            where TSetting : class, new()
        {
            return cb.Register(ctx =>
            {
                var configuration = ctx.Resolve<IConfiguration>();

                var setting = new TSetting();
                if (configurationSection != null)
                    configuration = configuration.GetSection(configurationSection);

                configuration.Bind(setting);

                return setting;
            });
        }
    }
}
