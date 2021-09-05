using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Renewal.Application.ResultObjects;

namespace Renewal.API.Extensions
{
    public static class ActionResultExtensions
    {
        public static void SetValidationResult(this ActionExecutingContext context, AppResultDetail resultDetail,
            HttpStatusCode httpCode)
        {
            var response = context.HttpContext.Response;
            context.Result = CreatedResult(response, resultDetail, httpCode);
        }

        public static void SetExceptionResult(this ExceptionContext context, AppResultDetail resultDetail,
            HttpStatusCode httpCode)
        {
            context.ExceptionHandled = true;
            var response = context.HttpContext.Response;
            context.Result = CreatedResult(response, resultDetail, httpCode);
        }

        public static void SetNoContentResult(this ExceptionContext context, AppResultDetail resultDetail,
            HttpStatusCode httpCode)
        {
            var response = context.HttpContext.Response;
            context.Result = CreatedResult(response, resultDetail, httpCode);
        }

        private static ObjectResult CreatedResult(HttpResponse response, AppResultDetail resultDetail, HttpStatusCode httpCode)
        {
            response.StatusCode = (int)httpCode;
            return new ObjectResult(resultDetail);
        }
    }
}
