using LightFrame.EntityFramework;
using LightFrame.Messaging;
using LightFrame.RabbitMq;
using LightFrame.SampleCore.Domain.Context;
using LightFrame.SampleCore.Handlers;
using LightFrame.SampleMessages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LightFrame.SampleApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IHandler, AddItemHandler>();

            services.AddDbContext<InventoryContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IInventoryContext, InventoryContext>();

            services.AddServiceBus(Configuration);
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IApplicationLifetime lifetime, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseDatabaseUnitOfWork<InventoryContext>();
            app.UseMvc();
            app.UseServiceBus(lifetime);
        }
    }
}
