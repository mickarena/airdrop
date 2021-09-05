using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Renewal.Application.Common.Logging
{
    public class CustomLogEnricher : ILogEventEnricher, ICustomLogEnricher
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public string CorrelationId { get; set; }
        public string RequestContext { get; set; }
        public string ClientIp { get; set; }
        public string IntegrationTestKey { get; set; }

        public CustomLogEnricher()
        {
            GetContextInfo();
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            GetContextInfo();

            logEvent.AddOrUpdateProperty(new LogEventProperty("RequestContext", new ScalarValue(RequestContext)));
            logEvent.AddOrUpdateProperty(new LogEventProperty("CorrelationId", new ScalarValue(CorrelationId)));
            logEvent.AddOrUpdateProperty(new LogEventProperty("ClientIp", new ScalarValue(ClientIp)));
        }

        private void GetContextInfo()
        {
            if ((!(ServiceProvider?.GetService<IHttpContextAccessor>()?.HttpContext is HttpContext httpContext)))
                return;

            var headers = httpContext.Request.Headers;
            ClientIp = headers[Renewal.Application.Common.Constants.HeaderInformation.ClientIp];
            RequestContext = headers[Renewal.Application.Common.Constants.HeaderInformation.HeaderContext];
            CorrelationId = headers[Renewal.Application.Common.Constants.HeaderInformation.CorrelationId];
            IntegrationTestKey = headers[Renewal.Application.Common.Constants.HeaderInformation.IntegrationTestKey];
        }
    }
}
