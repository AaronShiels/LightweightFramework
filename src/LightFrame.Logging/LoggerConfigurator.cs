using LightFrame.Logging.Enrichers;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace LightFrame.Logging
{
    public static class LoggerConfigurator
    {
        public static ILogger Default(IConfigurationSection configSection)
        {
            var settings = new Settings();
            configSection.Bind(settings);

            var logConfig = new LoggerConfiguration();
            logConfig.Enrich.With(new ApplicationEnricher(settings.Application));
            logConfig.Enrich.With(new EnvironmentEnricher(settings.Application));

            logConfig.MinimumLevel.Is(settings.LogLevel);

            logConfig.WriteTo.RollingFile("log-{Date}.txt");
            logConfig.WriteTo.ColoredConsole();

            if (settings.SeqUrl != null)
                logConfig.WriteTo.Seq(settings.SeqUrl);

            return logConfig.CreateLogger();
        }
    }
}
