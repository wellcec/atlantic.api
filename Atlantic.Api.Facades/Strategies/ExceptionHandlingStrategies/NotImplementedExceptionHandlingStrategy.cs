using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Serilog;

using Atlantic.Api.Models;

namespace Atlantic.Api.Facades.Strategies.ExceptionHandlingStrategies
{
    [ExcludeFromCodeCoverage]
    public class NotImplementedExceptionHandlingStrategy : ExceptionHandlingStrategy
    {
        private readonly ILogger _logger;

        public NotImplementedExceptionHandlingStrategy(ILogger logger)
        {
            _logger = logger;
        }

        public override async Task<HttpContext> HandleAsync(HttpContext context, Exception exception)
        {
            var notImplementedException = exception as NotImplementedException;
            _logger.Error(notImplementedException, "[{@User}] Error: {@Exception}", context.Request.Headers[Constants.BLIP_USER_HEADER], notImplementedException?.Message);
            context.Response.StatusCode = StatusCodes.Status501NotImplemented;

            return await Task.FromResult(context);
        }
    }
}
