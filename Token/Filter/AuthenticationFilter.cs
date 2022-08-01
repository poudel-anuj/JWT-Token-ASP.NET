using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using Token.Result;

namespace Token.Filter
{
    public class AuthenticationFilter:Attribute,IAuthenticationFilter
    {
        public bool AllowMultiple => true;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var authorization = context.Request.Headers.Authorization;
            if(authorization == null)
            {
                return;
            }
            if(authorization.Scheme != "Bearer")
            {
                return ;
            }

            var param = authorization.Parameter;
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principle = tokenHandler.ValidateToken(param,GetValidationParameter(),out var token);
            }
            catch 
            {
                return;
            }
        }
                
        public TokenValidationParameters GetValidationParameter()
        {
            byte[] secretKey = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["SecretKey"]);
            var tokenValidationParamters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateLifetime = true,    
                IssuerSigningKey = new SymmetricSecurityKey(secretKey)
            };
            return tokenValidationParamters;    
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var challenge = new AuthenticationHeaderValue("Bearer");
            context.Result = new ChallangeOnUthorizatizedResult(challenge, context.Result);
            return Task.FromResult(0);
        }

    }
}