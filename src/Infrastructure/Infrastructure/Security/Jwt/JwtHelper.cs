using Application.Dtos;
using Application.Interfaces.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Infrastructure.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
       // private readonly IConfiguration _configuration;
        private readonly TokenOptions _tokenOptions;

        public JwtHelper(IConfiguration configuration)
        {
           // _configuration = configuration;
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateAccessToken()
        {
            SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials credentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            JwtSecurityToken jwt = CreateJwtSecurityToken(_tokenOptions, credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string token = handler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(_tokenOptions.AccessTokenExpiration),
                RefreshToken = CreateRefreshToken()
            };

        }

        private string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }

        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, SigningCredentials credentials)
        {
            JwtSecurityToken jwt = new JwtSecurityToken(
                audience: tokenOptions.Audience,
                issuer: tokenOptions.Issuer,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddMinutes(tokenOptions.AccessTokenExpiration),
                notBefore: DateTime.UtcNow,
                claims: SetClaims()
                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims()
        {
            List<Claim> claims = new List<Claim>();
            return claims;
        }
    }
}
