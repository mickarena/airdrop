using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Renewal.Application.Common;
using Renewal.Application.ExtensionService.IService;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;

namespace Renewal.API.Extensions.HealthCheck
{
    public class IdentityServerHealthCheck : IHealthCheck
    {
        private readonly IPingService _pingService;
        private readonly IOptions<AppSettingsConfiguration> _config;
        public IdentityServerHealthCheck(IPingService pingService, IOptions<AppSettingsConfiguration> config)
        {
            _config = config;
            _pingService = pingService;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var header = new Dictionary<string, string>()
                {
                    {Constants.HeaderInformation.HeaderContext,Constants.HeaderInformation.HeaderContextValueStrata}
                };
                var result = await _pingService.Ping(_config.Value.PingServiceUrls.IdentityServer, HttpMethod.Get, header);

                if (result == HealthStatus.Healthy)
                    return HealthCheckResult.Healthy(Constants.HealthCheckMessage.Healthy);
                if (result == HealthStatus.Degraded)
                    return HealthCheckResult.Degraded(Constants.HealthCheckMessage.Degraded);

                return HealthCheckResult.Unhealthy(Constants.HealthCheckMessage.Unhealthy);
            }
            catch
            {
                return HealthCheckResult.Unhealthy(Constants.HealthCheckMessage.Unhealthy);
            }

        }
    }
}
