using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace Adform_ToDo.Filters
{
    /// <summary>
    /// Add CorrelationId header parameters.
    /// </summary>
    public class CorrelationIdOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Custom-Correlation-Id",
                In = ParameterLocation.Header,
                Description = "Identifier to track a request/response",
                Required = false
            });
        }
    }
}
