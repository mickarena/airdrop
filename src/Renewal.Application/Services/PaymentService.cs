using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Renewal.Application.Common;
using Renewal.Application.ResultObjects;

namespace Renewal.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ILogger<PaymentService> _logger;
        private static IHttpClientFactory _httpClientFactory { get; set; }
        private readonly string _paymentServiceEndpointUrl;
        private readonly string _context;

        public PaymentService(IHttpClientFactory httpClientFactory,
                            IOptions<AppSettingsConfiguration> config)
        {
            _httpClientFactory = httpClientFactory;
            _paymentServiceEndpointUrl = config.Value.PaymentServiceEndpointUrl;
            _context = config.Value.Products[0].Context;
        }
        public async Task<AbstractResult<bool>> GetIsLockPayment(string policyReferenceNumber)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_paymentServiceEndpointUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Context", _context);

            var url = Constants.Urls.GetIsLockPaymentV3 + "?policyReferenceNumber=" + policyReferenceNumber;
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<AppSuccessResult<bool>>(responseBody);

                return result;
            }

            return new AppErrorResult<bool>(false, "Get isLock payment failed!");
        }
    }
}