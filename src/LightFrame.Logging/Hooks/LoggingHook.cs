using System;
using System.Threading.Tasks;
using LightFrame.Core;
using Serilog;
using System.Diagnostics;

namespace LightFrame.Logging.Hooks
{
    internal class LoggingHook : IHook
    {
        private readonly ILogger _log;
        private readonly Stopwatch _stopwatch;

        public LoggingHook(ILogger log)
        {
            _log = log;
            _stopwatch = new Stopwatch();
        }

        public Task Before(object message)
        {
            _stopwatch.Start();

            _log.Debug("Received message {Message}.", message.GetType().FullName);

            return TaskExt.Complete;
        }

        public Task After(object message, Exception exception)
        {
            if (exception != null)
                _log.Error(exception, "Encountered exception handling message {Message}.", message.GetType().FullName);

            _stopwatch.Stop();

            _log.Debug("Handled message {Message} in {Elapsed}.", message.GetType().FullName, TimeSpan.FromMilliseconds(_stopwatch.ElapsedMilliseconds));

            return TaskExt.Complete;
        }

        public int Order => 100;
    }
}
