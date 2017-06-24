using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using NganHangTracNghiem.Models;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;

namespace NganHangTracNghiem
{
    public class MyAuthorizationServerProvider: OAuthAuthorizationServerProvider
    {
        ObjectiveTestEntities data = new ObjectiveTestEntities();
        public override async Task ValidateClientAuthentication (OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials (OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            User user = (from u in data.Users where u.Username==context.UserName && u.Password==context.Password select u).SingleOrDefault();
            if (user != null && user.Username != null && user.Username != "")
            {
                identity.AddClaim(new Claim("username", user.Username));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Tên hoặc mật khẩu sai");
                return;
            }

        }
    }
}