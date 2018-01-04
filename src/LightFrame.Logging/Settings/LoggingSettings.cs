using Serilog.Events;

namespace LightFrame.Logging.Settings
{
    internal class LoggingSettings
    {
        public LogEventLevel LogLevel { get; }
        public string SeqUrl { get; }
    }
}
