using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LightFrame.EntityFramework
{
    public static class Extensions
    {
        public static IApplicationBuilder UseDatabaseUnitOfWork<TDbContext>(this IApplicationBuilder app) where TDbContext : DbContext
        {
            return app.Use(async (context, next) =>
            {
                var dbContext = context.RequestServices.GetService<TDbContext>();

                await next();

                await dbContext.SaveChangesAsync();
            });
        }
    }
}
