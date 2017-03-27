using estore_common;
using Microsoft.Owin.Security;
using System;
using System.Configuration;
using System.IdentityModel.Tokens;

namespace estore_api.Infrastructure
{
    public class EStoreJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        public string SignatureAlgorithm
        {
            get { return "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256"; }
        }

        public string DigestAlgorithm
        {
            get { return "http://www.w3.org/2001/04/xmlenc#sha256"; }
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null) throw new ArgumentNullException("data");

            var issuer = "localhost";
            var audience = "all";
            var key = Convert.FromBase64String(ConfigurationManager.AppSettings[WebConfigConstants.SecurityKey]);
            var now = DateTime.UtcNow;
            var expires = now.AddMinutes(double.Parse(ConfigurationManager.AppSettings[WebConfigConstants.AccessTokenExpirationMinutes]));
            
            var signingCredentials = new SigningCredentials(
                                        new InMemorySymmetricSecurityKey(key),
                                        SignatureAlgorithm,
                                        DigestAlgorithm);
            var token = new JwtSecurityToken(issuer, audience, data.Identity.Claims,
                                             now, expires, signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}