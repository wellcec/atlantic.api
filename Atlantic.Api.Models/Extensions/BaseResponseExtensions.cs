using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using Atlantic.Api.Models.Responses;

namespace Atlantic.Api.Models.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class BaseResponseExtensions
    {
        public static IActionResult ToActionResult(this BaseResponse response)
        {
            return new ObjectResult(response)
            {
                StatusCode = (int)response.Code
            };
        }
    }
}
