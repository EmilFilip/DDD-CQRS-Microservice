using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace STC.Shared.Infrastructure.Authentication
{

    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string _key;

        public JwtAuthenticationManager(string key)
        {
            _key = key;
        }

        public AccessToken GetToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, username)
            }),
                Expires = DateTime.UtcNow.AddMinutes(2),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AccessToken(
                token: tokenHandler.WriteToken(token),
                expiresIn: GetTokenExpirationTimeInMinutes(token));
        }

        private int GetTokenExpirationTimeInMinutes(SecurityToken token)
        {
            if (token == null)
            {
                return 0;
            }

            return (int)(token.ValidTo - token.ValidFrom).TotalSeconds;
        }
    }
}
