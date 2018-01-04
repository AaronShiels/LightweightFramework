using Serilog.Core;
using Serilog.Events;

namespace LightFrame.Logging.Enrichers
{
    internal class ApplicationEnricher : ILogEventEnricher
    {
        private readonly string _application;
        private const string ApplicationKey = "Application";

        public ApplicationEnricher(string application)
        {
            _application = application;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(ApplicationKey, _application));
        }
    }
}
