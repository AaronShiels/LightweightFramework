using Autofac;
using Autofac.Extensions.DependencyInjection;
using LightFrame.MvcApplication.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

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
        }

        public IConfigurationRoot Configuration { get; }

        public virtual IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var builder = new ContainerBuilder();
            ConfigureContainer(builder);

            builder.Populate(services);

            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }

        public abstract void ConfigureContainer(ContainerBuilder builder);

        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var webLogger = app
                .ApplicationServices
                .GetService<Serilog.ILogger>()
                .ForContext("Framework", "Web");

            loggerFactory.AddSerilog(webLogger);

            app.UseStaticFiles();
            app.UseActionMiddleware();
            app.UseMvc();
        }
    }
}
