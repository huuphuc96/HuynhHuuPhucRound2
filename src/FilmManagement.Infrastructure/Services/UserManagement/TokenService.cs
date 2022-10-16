using FilmManagement.Core.Interfaces.UserManagement;
using FilmManagement.Core.Models.Settings;
using FilmManagement.Core.Models.User.Response;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FilmManagement.Infrastructure.Services.UserManagement
{
    public class TokenService : ITokenService
    {
        private readonly AuthSetting authSetting;
        public TokenService(IOptions<AppSetting> appSetting)
        {
            authSetting = appSetting.Value.AuthSetting;
            if (authSetting == null)
            {
                authSetting = new AuthSetting();
                authSetting.SecretKey = "veryVerySecretKey";
                authSetting.AccessTokenExpiresInSecconds = 900000;
            }
        }

        /// <summary>
        /// Instance token with JWT
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public TokenResponse CreateTokenBearer(string userId)
        {
            return new TokenResponse
            {
                AccessToken = GenerateJwtToken(userId),
                TokenType = "Bearer",
                ExpiresIn = authSetting.AccessTokenExpiresInSecconds
            };
        }

        /// <summary>
        /// Gen Jwt
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private string GenerateJwtToken(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return string.Empty;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSetting.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(authSetting.AccessTokenExpiresInSecconds),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
