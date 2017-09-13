using System.Threading.Tasks;
using Serilog;
using LightFrame.Core.Middleware;

namespace LightFrame.Sample.Middleware
{
    public class MiddlewareC : IActionMiddleware
    {
        private readonly ILogger _log;

        public MiddlewareC(ILogger log)
        {
            _log = log;
        }

        public int Priority => 22;

        public async Task Invoke(ActionMetadata message, ActionDelegate next)
        {
            _log.Information("Beginning C");

            await next.Invoke(message);

            _log.Information("Ending C");
        }
    }
}
