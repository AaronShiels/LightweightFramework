using Microsoft.AspNetCore.Builder;

namespace LightFrame.MvcApplication.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseActionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ActionMiddleware>();
        }
    }
}
