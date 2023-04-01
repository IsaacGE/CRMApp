using CRMApi.Models;
using CRMApi.DAOs;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Routing;
using System.IdentityModel.Tokens.Jwt;

namespace CRMApi.Security
{
    /// <summary>
    /// JWT Token generator class using "secret-key"
    /// more info: https://self-issued.info/docs/draft-ietf-oauth-json-web-token.html
    /// </summary>
    internal static class TokenGenerator
    {
        private static readonly ConfigurationDAO configDAO = new();

        public static string GenerateTokenJwt(User user)
        {
            try
            {
                List<Configuration> configList = configDAO.GetConfigurationByParams(new Configuration { Type = "tokenJWT" });
                var secretKey = configList.FirstOrDefault(c => c.ConfigKey == "secretKey");
                var audienceToken = configList.FirstOrDefault(c => c.ConfigKey == "audience");
                var issuerToken = configList.FirstOrDefault(c => c.ConfigKey == "issuer");
                var expireTime = configList.FirstOrDefault(c => c.ConfigKey == "expireTime");

                var securityKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(secretKey.ConfigValue));
                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var headers = new JwtHeader(signingCredentials);

                DateTime expiresDate = DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime.ConfigValue));
                int timeExpirationSeconds = (int)(expiresDate - new DateTime(1970, 1, 1)).TotalSeconds;

                ClaimsIdentity claimsIdentity = new(new[] {
                    new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.Type),
                    new Claim(ClaimTypes.Name, $"{user.Name} {user.LastName}")
                });

                var payload = new JwtPayload {
                    {"exp", timeExpirationSeconds },
                    {"iss", issuerToken.ConfigValue },
                    {"aud", audienceToken.ConfigValue },
                    { "sub", new { user.Id, user.Role.Type, name = $"{user.Name} { user.LastName }" } }
                };

                var jwtSecurityToken = new JwtSecurityToken(headers, payload);
                var jwtSecurityHandler = new JwtSecurityTokenHandler();

                var jwtTokenString = jwtSecurityHandler.WriteToken(jwtSecurityToken);

                return jwtTokenString;

                //    // create token to the user
                //    var tokenHandler = new JwtSecurityTokenHandler();
                //    var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                //        audience: audienceToken.ConfigValue,
                //        issuer: issuerToken.ConfigValue,
                //        subject: claimsIdentity,
                //        notBefore: DateTime.UtcNow,
                //        expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime.ConfigValue)),
                //        signingCredentials: signingCredentials);

                //    var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
                //    return jwtTokenString;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

