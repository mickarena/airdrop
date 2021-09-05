using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Renewal.API.Extensions;
using Renewal.Application.ResultObjects;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Renewal.API.Filters
{
    public class ModelValidatorFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger<ModelValidatorFilterAttribute> _logger;

        public ModelValidatorFilterAttribute(ILogger<ModelValidatorFilterAttribute> logger)
        {
            _logger = logger;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var modelState = context.ModelState;
            if (!modelState.IsValid)
            {
                var errors = modelState
                    .Select(key => { return key.Value.Errors.Select(y => y.ErrorMessage); });
                var messages = new List<string>();

                foreach (var key in errors) messages.AddRange(key);

                var resultDetail = new AppResultDetail(false, messages.Distinct().OrderBy(m => m));

                context.SetValidationResult(resultDetail, HttpStatusCode.BadRequest);

                _logger.LogError(JsonConvert.SerializeObject(messages));
            }
        }
    }
}
