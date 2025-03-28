using System;
using System.Diagnostics.CodeAnalysis;

namespace Atlantic.Api.Models.Token.Responses.Models
{
    [ExcludeFromCodeCoverage]
    public class Token
    {
        public string AccessToken { get; set; }

        public string TokenType { get; set; }

        public DateTime ExpiresIn { get; set; }

        public string Scope { get; set; }

        public string Jti { get; set; }
    }
}
