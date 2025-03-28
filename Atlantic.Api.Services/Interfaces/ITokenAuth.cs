using System.Threading.Tasks;

using Atlantic.Api.Models.Token.Responses.Models;

namespace Atlantic.Api.Services.Interfaces
{
    public interface ITokenAuthService
    {
        Token Token { get; }

        Task GenerateTokenAsync();
    }
}
