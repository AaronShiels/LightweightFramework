using System.Threading.Tasks;
using Serilog;
using LightFrame.Core.Middleware;

namespace LightFrame.Sample.Middleware
{
    public class MiddlewareB : IActionMiddleware
    {
        private readonly ILogger _log;

        public MiddlewareB(ILogger log)
        {
            _log = log;
        }

        public int Priority => 21;

        public async Task Invoke(ActionMetadata message, ActionDelegate next)
        {
            _log.Information("Beginning B");

            await next.Invoke(message);

            _log.Information("Ending B");
        }
    }
}
