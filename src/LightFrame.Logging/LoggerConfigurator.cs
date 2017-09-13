using LightFrame.Logging.Enrichers;
using Serilog;

namespace LightFrame.Logging
{
    public static class LoggerConfigurator
    {
        public static ILogger Default(LoggingSettings settings)
        {
            var logConfig = new LoggerConfiguration();
            logConfig.Enrich.With(new ApplicationEnricher(settings.Application));
            logConfig.Enrich.With(new EnvironmentEnricher(settings.Environment));

            logConfig.MinimumLevel.Is(settings.LogLevel);

            logConfig.WriteTo.RollingFile("logs\\log-{Date}.txt");
            logConfig.WriteTo.ColoredConsole();

            if (settings.SeqUrl != null)
                logConfig.WriteTo.Seq(settings.SeqUrl);

            return Log.Logger = logConfig.CreateLogger();
        }
    }
}
