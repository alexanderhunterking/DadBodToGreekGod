using DadBodToGreekGod.Models.Token;

namespace DadBodToGreekGod.Services.Token
{
    public interface ITokenService
    {
        Task<TokenResponse?> GetTokenAsync(TokenRequest model);
    }
}