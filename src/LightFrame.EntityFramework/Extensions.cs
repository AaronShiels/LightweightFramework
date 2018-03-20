using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace LightFrame.EntityFramework
{
    public static class Extensions
    {
        public static IApplicationBuilder UseDatabaseUnitOfWork<TDbContext>(this IApplicationBuilder app) where TDbContext : DbContext
        {
            return app.Use(async (context, next) =>
            {
                var dbContext = context.RequestServices.GetRequiredService<TDbContext>();

                await DatabaseUnitOfWork(dbContext, next);
            });
        }

        private async static Task DatabaseUnitOfWork<TDbContext>(TDbContext dbContext, Func<Task> next) where TDbContext : DbContext
        {
            await next();

            await dbContext.SaveChangesAsync();
        }
    }
}
