using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ServiceCompanyTaskManager.Api.Services
{
    public class AuthOptions
    {
        public const string ISSUER = "ServiceCompanyAuthServer";
        public const string AUDIENCE = "ServiceCompanyAuthClient";
        const string KEY = "servicecompanysupersecret_secretkey!123";
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}