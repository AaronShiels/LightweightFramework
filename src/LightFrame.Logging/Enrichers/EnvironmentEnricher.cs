using Serilog.Core;
using Serilog.Events;

namespace LightFrame.Logging.Enrichers
{
    internal class EnvironmentEnricher : ILogEventEnricher
    {
        private readonly string _environment;
        private const string EnvironmentKey = "Environment";

        public EnvironmentEnricher(string environment)
        {
            _environment = environment;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(EnvironmentKey, _environment));
        }
    }
}
