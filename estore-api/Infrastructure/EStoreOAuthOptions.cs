using Microsoft.Owin.Security.OAuth;
using System;

namespace estore_api.Infrastructure
{
    public class EStoreOAuthOptions : OAuthAuthorizationServerOptions
    {
        public EStoreOAuthOptions()
        {
            TokenEndpointPath = new Microsoft.Owin.PathString("/oauth2/token");
            AuthorizeEndpointPath = new Microsoft.Owin.PathString("/oauth2/login");
            AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60);
            AccessTokenFormat = new EStoreJwtFormat();
            Provider = new EStoreOAuthProvider();
            AllowInsecureHttp = true;
        }
    }
}