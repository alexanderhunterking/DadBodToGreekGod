using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using DadBodToGreekGod.Data.Entities;
using DadBodToGreekGod.Models.Token;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace DadBodToGreekGod.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<UserEntity> _userManager;

        public TokenService(IConfiguration configuration, UserManager<UserEntity> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<TokenResponse?> GetTokenAsync(TokenRequest model)
        {
            UserEntity? entity = await GetValidUserAsync(model);
            if (entity is null)
            {
                return null;
            };

            return await GenerateTokenAsync(entity);
        }

        private async Task<UserEntity?> GetValidUserAsync(TokenRequest model)
        {
            var userEntity = await _userManager.FindByNameAsync(model.UserName);
            if (userEntity is null)
            {
                return null;
            }
            var isValidPassword = await _userManager.CheckPasswordAsync(userEntity, model.Password);
            if (isValidPassword == false)
            {
                return null;
            }
            return userEntity;
        }

        private async Task<TokenResponse> GenerateTokenAsync(UserEntity entity)
        {
            List<Claim> claims = await GetUserClaimsAsync(entity);

            // Add UserId claim
            claims.Add(new Claim(ClaimTypes.NameIdentifier, entity.Id.ToString()));

            SecurityTokenDescriptor tokenDescriptor = GetTokenDescriptor(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            TokenResponse response = new TokenResponse()
            {
                Id = entity.Id,
                Token = tokenHandler.WriteToken(token),
                IssuedAt = token.ValidFrom,
                Expires = token.ValidTo
            };

            return response;
        }

        private async Task<List<Claim>> GetUserClaimsAsync(UserEntity entity)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, entity.Id.ToString()),
                new Claim(ClaimTypes.Name, entity.UserName!),
                new Claim(ClaimTypes.Email, entity.Email!)
            };

            var roles = await _userManager.GetRolesAsync(entity);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SecurityTokenDescriptor GetTokenDescriptor(List<Claim> claims)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
            var secret = new SymmetricSecurityKey(key);
            var signingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Issuer = _configuration["Jwt:Issuer"]!,
                Audience = _configuration["Jwt:Audience"]!,
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(14),
                SigningCredentials = signingCredentials
            };

            return tokenDescriptor;
        }
    }
}