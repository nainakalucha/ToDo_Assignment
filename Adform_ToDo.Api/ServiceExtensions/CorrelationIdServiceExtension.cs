using CorrelationId.DependencyInjection;
using CorrelationId.HttpClient;
using Adform_ToDo.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Adform_ToDo.API.Services
{
    /// <summary>
    /// Extension for IService collection for adding CorrelationId Handler and setting defaults.
    /// </summary>
    public static class CorrelationIdServiceExtension
    {
        /// <summary>
        /// AddCorrelationIdHandlerAndDefaults
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCorrelationIdHandlerAndDefaults(this IServiceCollection services)
        {
            services.AddTransient<CorrelationIdDelegatingHandler>();

            services.AddHttpClient("Adform_ToDo_Client")
                .AddCorrelationIdForwarding()           // add the handler to attach the correlation ID to outgoing requests for this named client
                .AddHttpMessageHandler<CorrelationIdDelegatingHandler>();

            services.AddDefaultCorrelationId(options =>
            {
                options.CorrelationIdGenerator = () => Guid.NewGuid().ToString();
                options.AddToLoggingScope = true;
                options.EnforceHeader = false;
                options.IgnoreRequestHeader = false;
                options.IncludeInResponse = true;
                options.RequestHeader = "Custom-Correlation-Id";
                options.ResponseHeader = "X-Correlation-Id";
                options.UpdateTraceIdentifier = false;
            });
            return services;
        }
    }
}
