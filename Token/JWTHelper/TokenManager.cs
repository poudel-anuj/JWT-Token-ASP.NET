using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using Microsoft.IdentityModel.Tokens;
using Token.Models;

namespace Token.JWTHelper
{
    public class TokenManager
    {
        public static string GenerateToken(Admin ad)
        {
            var SecretKey = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["SecretKey"]);
            var tokenHander = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                    new Claim[]
                    {
                        //new Claim(ClaimTypes.Name ,ad.FullName),
                        //new Claim(ClaimTypes.Email ,ad.EmailAddress),
                        new Claim(ClaimTypes.Role ,ad.RoleName),
          

                    }
                ),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(SecretKey),SecurityAlgorithms.HmacSha256)
            };

            var securityToken = tokenHander.CreateToken(tokenDescriptor);
            return tokenHander.WriteToken(securityToken);
        }
    }
}