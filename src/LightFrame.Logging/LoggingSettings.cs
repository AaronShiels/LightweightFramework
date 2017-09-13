using Serilog.Events;

namespace LightFrame.Logging
{
    public class LoggingSettings
    {
        public string Application { get; }
        public string Environment { get; }
        public LogEventLevel LogLevel { get; }
        public string SeqUrl { get; }
    }
}
