using System.Threading.Tasks;
using Serilog;
using LightFrame.Core.Middleware;

namespace LightFrame.Sample.Middleware
{
    public class MiddlewareA : IActionMiddleware
    {
        private readonly ILogger _log;

        public MiddlewareA(ILogger log)
        {
            _log = log;
        }

        public int Priority => 20;

        public async Task Invoke(ActionMetadata message, ActionDelegate next)
        {
            _log.Information("Beginning A");

            await next.Invoke(message);

            _log.Information("Ending A");
        }
    }
}
