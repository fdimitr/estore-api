using estore_common;
using Microsoft.Owin.Security.Jwt;
using System;
using System.Configuration;

namespace estore_api.Infrastructure
{
    public class EStoreJwtOptions : JwtBearerAuthenticationOptions
    {
        public EStoreJwtOptions()
        {
            var issuer = "localhost";
            var audience = "all";
            var key = Convert.FromBase64String(ConfigurationManager.AppSettings[WebConfigConstants.SecurityKey]);

            AllowedAudiences = new[] { audience };
            IssuerSecurityTokenProviders = new[]
            {
            new SymmetricKeyIssuerSecurityTokenProvider(issuer, key)
        };
        }
    }
}