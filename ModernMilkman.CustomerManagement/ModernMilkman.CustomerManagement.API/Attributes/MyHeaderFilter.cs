using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernMilkman.CustomerManagement.API.Attributes
{
    /// <summary>
    /// Operation filter to add the requirement of the custom header
    /// </summary>
    public class MyHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "UserId",
                In = ParameterLocation.Header,
                Required = false,
                Example = new OpenApiString("user")
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Password",
                In = ParameterLocation.Header,
                Required = false,
                Example = new OpenApiString("pass")
            });
        }
    }
}
