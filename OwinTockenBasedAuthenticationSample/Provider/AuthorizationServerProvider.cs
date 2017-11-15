using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OwinTockenBasedAuthenticationSample.Provider
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //Here you need to set the user infor in ClaimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            //Like this you can add more claims (info)
            claimsIdentity.AddClaim(new Claim("UserName", context.UserName));

            AuthenticationProperties authProps = CreateAuthenticationProperties(context.UserName);
            AuthenticationTicket ticket = new AuthenticationTicket(claimsIdentity, authProps);

            context.Validated(ticket);
        }

        private AuthenticationProperties CreateAuthenticationProperties(string userName)
        {
            AuthenticationProperties authProps = null;
            authProps = new AuthenticationProperties(new Dictionary<string, string>{
                    {
                        "UserName", userName
                    },
                    {
                        "CurrentDate", DateTime.Now.ToString("yyyy-MM-dd")
                    }
                });
            return authProps;
        }
    }
}