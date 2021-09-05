using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Renewal.Application.Common.Logging;

namespace Renewal.Application.Common
{
    public static class AtlantaHttpClientHelper
    {
        public static HttpRequestMessage SetAtlantaHeaders(
            this HttpRequestMessage httpRequestMessage,
            ICustomLogEnricher customLogEnricher)
        {
            httpRequestMessage
                .SetHeader(Constants.HeaderInformation.IntegrationTestKey, customLogEnricher.IntegrationTestKey)
                .SetHeader(Constants.HeaderInformation.HeaderContext, customLogEnricher.RequestContext)
                .SetHeader(Constants.HeaderInformation.CorrelationId, customLogEnricher.CorrelationId)
                .SetHeader(Constants.HeaderInformation.ClientIp, customLogEnricher.ClientIp);

            return httpRequestMessage;
        }

        public static async Task<HttpResponseMessage> SendCustomAsync<T>(
            this IHttpClientFactory httpClientFactory,
            string endpoint,
            T requestModel,
            ICustomLogEnricher logEnricher)
            where T : class
        {
            var requestBody = JsonConvert.SerializeObject(requestModel);

            var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
            {
                Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
            }
                .SetAtlantaHeaders(logEnricher);

            var httpClient = httpClientFactory.CreateClient();
            return await httpClient.SendAsync(request);
        }

        public static async Task<HttpResponseMessage> SendAsync(
            this IHttpClientFactory httpClientFactory,
            string endpoint,
            HttpMethod method,
            Dictionary<string, string> headers)
        {
            var request = new HttpRequestMessage(method, endpoint);
            if (headers != null)
            {
                foreach (var (key, value) in headers)
                {
                    request.SetHeader(key, value.ToString());
                }
            }

            var httpClient = httpClientFactory.CreateClient();
            return await httpClient.SendAsync(request);
        }

        private static HttpRequestMessage SetHeader(
            this HttpRequestMessage httpRequestMessage,
            string key,
            string value)
        {
            if (httpRequestMessage.Headers.Contains(key))
                httpRequestMessage.Headers.Remove(key);

            if (value != null)
                httpRequestMessage.Headers.Add(key, value);

            return httpRequestMessage;
        }
    }
}
