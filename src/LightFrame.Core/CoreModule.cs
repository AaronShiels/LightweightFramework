using Autofac;
using LightFrame.Core.Settings;

namespace LightFrame.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSetting<GeneralSettings>("General");
        }
    }
}
