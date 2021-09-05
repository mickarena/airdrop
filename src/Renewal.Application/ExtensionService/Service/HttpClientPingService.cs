using Microsoft.Extensions.Diagnostics.HealthChecks;
using Renewal.Application.Common;
using Renewal.Application.ExtensionService.IService;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HttpMethod = System.Net.Http.HttpMethod;

namespace Renewal.Application.ExtensionService.Service
{
    public class HttpClientPingService : IPingService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpClientPingService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HealthStatus> Ping(string host, HttpMethod httpMethod, Dictionary<string, string> headers)
        {
            var response = await _httpClientFactory.SendAsync(host, httpMethod, headers);


            if (response.StatusCode == HttpStatusCode.OK)
            {
                if (httpMethod == HttpMethod.Head)
                {
                    return HealthStatus.Healthy;
                }

                var responseBody = await response.Content.ReadAsStringAsync();
                if (responseBody.Equals(HealthStatus.Healthy.ToString()))
                    return HealthStatus.Healthy;

                if (responseBody.Equals(HealthStatus.Degraded.ToString()))
                    return HealthStatus.Degraded;
            }

            return HealthStatus.Unhealthy;
        }

        public async Task<HealthStatus> Ping(string host, HttpMethod httpMethod, HttpStatusCode expectedCode)
        {
            var response = await _httpClientFactory.SendAsync(host, httpMethod, new Dictionary<string, string>());

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return HealthStatus.Healthy;
            }

            return HealthStatus.Unhealthy;
        }
    }
}
