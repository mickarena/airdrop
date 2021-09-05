using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Renewal.API.Filters
{
    public class SwaggerHeaderFilterAttribute : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema() { Type = "string" },
                Description = "Format: Bearer {token}",
                Required = true
            });

            var descriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;

            if(descriptor != null && descriptor.ControllerName.StartsWith("Renewal"))
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "Context",
                    In = ParameterLocation.Header,
                    Schema = new OpenApiSchema() { Type = "string" },
                    Required = true
                });
            }
        }
    }
}
