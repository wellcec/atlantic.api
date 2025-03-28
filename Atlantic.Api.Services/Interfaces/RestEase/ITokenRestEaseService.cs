using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using RestEase;

using Atlantic.Api.Models.Token.Responses;

namespace Atlantic.Api.Services.Interfaces.RestEase
{
    public interface ITokenRestEaseService : IDisposable
    {
        [Header("Authorization")]
        string Authorization { get; set; }

        [Post("/auth/oauth/token")]
        [Header("Content-Type", "application/x-www-form-urlencoded")]
        Task<GenerateTokenResponse> GetGeneratedTokenAsync([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> grantType);
    }
}
