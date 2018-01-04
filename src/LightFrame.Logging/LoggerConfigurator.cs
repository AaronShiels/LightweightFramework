using LightFrame.Core.Settings;
using LightFrame.Logging.Enrichers;
using LightFrame.Logging.Settings;
using Serilog;

namespace LightFrame.Logging
{
    public static class LoggerConfigurator
    {
        internal static ILogger Default(GeneralSettings generalSettings, LoggingSettings loggingSettings)
        {
            var logConfig = new LoggerConfiguration();
            logConfig.Enrich.With(new ApplicationEnricher(generalSettings.Name));
            logConfig.Enrich.With(new EnvironmentEnricher(generalSettings.Environment));

            logConfig.MinimumLevel.Is(loggingSettings.LogLevel);

            logConfig.WriteTo.RollingFile("logs\\log-{Date}.txt");
            logConfig.WriteTo.ColoredConsole();

            if (loggingSettings.SeqUrl != null)
                logConfig.WriteTo.Seq(loggingSettings.SeqUrl);

            return Log.Logger = logConfig.CreateLogger();
        }
    }
}
