using System;
using System.Threading.Tasks;
using Serilog;
using System.Diagnostics;
using LightFrame.Core.Middleware;

namespace LightFrame.Logging.Hooks
{
    internal class LoggingMiddleware : IActionMiddleware
    {
        private readonly ILogger _log;
        private readonly Stopwatch _stopwatch;

        public LoggingMiddleware(ILogger log)
        {
            _log = log;
            _stopwatch = new Stopwatch();
        }

        public async Task Invoke(ActionMetadata action, ActionDelegate next)
        {
            _stopwatch.Start();
            _log.Debug("Executing {ActionType} action {ActionDescription}.", action.Type, action.Description);

            try
            {
                await next(action);
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Encountered exception executing {ActionType} action {ActionDescription}.", action.Type, action.Description);
                throw ex;
            }
            finally
            {
                _stopwatch.Stop();
                _log.Debug("Executed {ActionType} action {ActionDescription} in {ExecutionTime}.", action.Type, action.Description, TimeSpan.FromMilliseconds(_stopwatch.ElapsedMilliseconds));
            }
        }

        public int Priority => 10;
    }
}
