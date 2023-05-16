using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace JsonWebToken.JwtService
{
    public class Service
    {
        private readonly string _jwtSecreteKey = "n2r5u8x/A?D(G+KbPeSgVkYp3s6v9y$B&E)H@McQfTjWmZq4t7w!z%C*F-JaNdRgUkXp2r5u8x/A?D(G+KbPeShVmYq3t6v9y$B&E)H@McQfTjWnZr4u7x!z%C*F-JaN";

        public Service(string secreteKey)
        {
            _jwtSecreteKey = secreteKey;
        }

      /*  public string GenerateToken(string username, string Password) 
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecreteKey));
            var entityCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: "Osj",
                    audience: "localhost",
                    claims : new[]
                    { 
                        new Claim("username", username),
                        new Claim("password",Password)
                    },
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: entityCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }*/

        public ClaimsPrincipal GetClaimsPrincipal(string token) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var myKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecreteKey));

            var validatePrincipal = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = "",
                ValidIssuer = "Osj",
                IssuerSigningKey = myKey,
            };

            return tokenHandler.ValidateToken(token, validatePrincipal, out _);
        }
    }
}