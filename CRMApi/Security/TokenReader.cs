using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CRMApi.Security
{
    public class TokenReader
    {
        public TokenReader() { }

        /// <summary>
        /// Obtener el id del usuario del token
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static int GetIdFromToken(string stream)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(stream);
                var tokenS = handler.ReadToken(stream) as JwtSecurityToken;

                var userId = tokenS.Claims.First(claim => claim.Type == "unique_name").Value;
                return Convert.ToInt32(userId);
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
    }
}
