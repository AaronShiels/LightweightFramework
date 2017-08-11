using Autofac;
using LightFrame.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LightFrame.MvcApplication
{
    public abstract class MvcStartUp
    {
        public MvcStartUp(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            Log.Logger = LoggerConfigurator.Default(Configuration.GetSection("Logging"));
        }

        public IConfigurationRoot Configuration { get; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public abstract void ConfigureContainer(ContainerBuilder builder);

        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

            app.UseMvc();
        }
    }
}
