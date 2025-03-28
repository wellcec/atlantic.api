
using System.Diagnostics.CodeAnalysis;

using Newtonsoft.Json;

namespace Atlantic.Api.Models.Token.Responses
{
    [ExcludeFromCodeCoverage]
    public class GenerateTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("jti")]
        public string Jti { get; set; }
    }
}
