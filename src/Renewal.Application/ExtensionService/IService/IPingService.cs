using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Renewal.Application.ExtensionService.IService
{
    public interface IPingService
    {
        Task<HealthStatus> Ping(string host, HttpMethod httpMethod, HttpStatusCode expectedCode);

        Task<HealthStatus> Ping(string host, HttpMethod httpMethod, Dictionary<string, string> headers);
    }
}
