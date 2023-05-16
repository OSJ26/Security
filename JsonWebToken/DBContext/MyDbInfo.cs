using JsonWebToken.CommonMethods;
using JsonWebToken.JwtService;
using JsonWebToken.Models;
using Microsoft.IdentityModel.Tokens;
using ServiceStack;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace JsonWebToken.DBContext
{
    public class MyDbInfo
    {
        CommonMethod objCommon = new CommonMethod();    
        public dynamic getData()
        {
            try 
            { 
                using(var db = objCommon.openConnection())
                {
                    var query = db.Select<User>();
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public dynamic Login(string username) 
        {
            try
            {
                using (var db = objCommon.openConnection())
                {
                    var query = db.Select<User>().Where<User>(x => x.Email.Equals(username));
                    if (query == null)
                    {
                        return false;
                    }
                    string token = GenerateToken(username);
                    return token;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private readonly string _jwtSecreteKey = "n2r5u8x/A?D(G+KbPeSgVkYp3s6v9y$B&E)H@McQfTjWmZq4t7w!z%C*F-JaNdRgUkXp2r5u8x/A?D(G+KbPeShVmYq3t6v9y$B&E)H@McQfTjWnZr4u7x!z%C*F-JaN";


        public string GenerateToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecreteKey));
            var entityCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: "Osj",
                    audience: "localhost",
                    claims: new[]
                    {
                        new Claim("username", username)
                    },
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: entityCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}