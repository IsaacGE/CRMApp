using Microsoft.IdentityModel.Tokens;

namespace CRMApi.Common
{
    public static class Constants
    {
        #region WEB APPLICATION CONFIGURATION

        public static string ConnectionString;
        public static string SecretKey;
        public static string Audience;
        public static string Issuer;
        public static SymmetricSecurityKey SecuritySecretKey;

        #endregion WEB APPLICATION CONFIGURATION
    }
}
