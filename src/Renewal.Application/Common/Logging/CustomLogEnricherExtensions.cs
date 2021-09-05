using Serilog;
using Serilog.Configuration;
using System;

namespace Renewal.Application.Common.Logging
{
    public static class CustomLogEnricherExtensions
    {
        public static LoggerConfiguration WithAtlantaLogEnricher(
            this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null)
                throw new ArgumentNullException(nameof(enrichmentConfiguration));

            return enrichmentConfiguration.With<CustomLogEnricher>();
        }
    }
}
