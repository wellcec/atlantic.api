using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using RestEase;

using Serilog;

using Atlantic.Api.Models;

namespace Atlantic.Api.Facades.Strategies.ExceptionHandlingStrategies
{
    public class ApiExceptionHandlingStrategy : ExceptionHandlingStrategy
    {
        private readonly ILogger _logger;

        public ApiExceptionHandlingStrategy(ILogger logger)
        {
            _logger = logger;
        }

        public override async Task<HttpContext> HandleAsync(HttpContext context, Exception exception)
        {
            var apiException = exception as ApiException;
            _logger.Error(apiException, "[{@User}] Error: {@Exception}", context.Request.Headers[Constants.BLIP_USER_HEADER], apiException.Message);
            context.Response.StatusCode = (int)apiException.StatusCode;

            return await Task.FromResult(context);
        }
    }
}
