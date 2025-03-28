using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Serilog;
using Serilog.Context;

using Atlantic.Api.Facades.Strategies.ExceptionHandlingStrategies;

namespace Atlantic.Api.Middleware
{
    [ExcludeFromCodeCoverage]
    /// <summary>
    /// Wraps all controller actions with a try-catch latch to avoid code repetition
    /// </summary>
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ErrorHandlingMiddleware
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;
        private readonly Dictionary<Type, ExceptionHandlingStrategy> _exceptionHandling;

        private const string CORRELATION_ID = "CorrelationId";
        private const string ERROR_HANDLING_MIDDLEWARE = "ErrorHandlingMiddleware";

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public ErrorHandlingMiddleware(RequestDelegate next,
                                       ILogger logger,
                                       Dictionary<Type, ExceptionHandlingStrategy> exceptionHandling)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _next = next;
            _logger = logger;
            _exceptionHandling = exceptionHandling;
        }

        /// <summary>
        /// Invoke Method, to validate requisition errors
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            var requestBody = string.Empty;
            context.Request.EnableBuffering();

            using (var reader = new StreamReader(context.Request.Body, leaveOpen: true))
            {
                requestBody = await reader.ReadToEndAsync();
                context.Request.Body.Position = default;
            }
            var requestId = Guid.NewGuid();

            using (LogContext.PushProperty(CORRELATION_ID, requestId.ToString()))
            {
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(requestBody, context, ex, requestId.ToString());
                }
            }
        }

        private async Task HandleExceptionAsync(string requestBody, HttpContext context, Exception exception, string requestId)
        {
            const string METHOD_NAME = "HandleExceptionAsync";

            if (_exceptionHandling.TryGetValue(exception.GetType(), out var handler))
            {
                context = await handler.HandleAsync(context, exception);
            }
            else
            {
                _logger.Error(
                    exception, 
                    "{@Middleware} | {@Method} | [requestId:{@RequestId}] Error: {@Exception}", 
                    ERROR_HANDLING_MIDDLEWARE, 
                    METHOD_NAME, 
                    requestId, 
                    exception.Message);

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
        }
    }
}
