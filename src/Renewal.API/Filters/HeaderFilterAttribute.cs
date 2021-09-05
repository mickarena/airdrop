using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using Renewal.Application.Models;
using Renewal.Application.Common.Logging;
using Renewal.Application.Common;
using Renewal.Application.ResultObjects;
using Renewal.API.Extensions;

namespace Renewal.API.Filters
{
    public class HeaderFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger<HeaderFilterAttribute> _logger;
        private readonly ITenantRequestModel _tenant;
        private readonly ICustomLogEnricher _logEnricher;

        public HeaderFilterAttribute(
            ILogger<HeaderFilterAttribute> logger,
            ITenantRequestModel tenant,
            ICustomLogEnricher logEnricher)
        {
            _logger = logger;
            _tenant = tenant;
            _logEnricher = logEnricher;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                if (!_tenant.IsValid())
                {
                    SetResult(context);
                }
            }
            catch
            {
                SetResult(context);
            }

            context.HttpContext.Response.Headers[Constants.HeaderInformation.CorrelationId] = _logEnricher.CorrelationId;
        }

        private void SetResult(ActionExecutingContext context)
        {
            var messages = new List<string>
            {
                new string("Tenant is not supported")
            };

            var resultDetail = new AppResultDetail(false, messages);

            context.SetValidationResult(resultDetail, HttpStatusCode.BadRequest);

            _logger.LogError(JsonConvert.SerializeObject(messages));
        }
    }
}
