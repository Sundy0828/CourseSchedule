using System;
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace CourseSchedule.Core.Providers
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            Guid clientIdGuid;
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }
            if (null == context.ClientId || null == clientSecret || !Guid.TryParse(clientId, out clientIdGuid))
            {
                context.SetError("invalid_credentials", "A valid client_Id and client_Secret must be provided.");
                context.Rejected();
                return;
            }
            //validate aginstdb or config: GetClient(clientIdGuid, clientSecret);
            bool isValidClient = ConfigurationManager.AppSettings["ClientId"] == clientId && ConfigurationManager.AppSettings["ClientSecret"] == clientSecret;
            if (!isValidClient)
            {
                context.SetError("invalid_credentials", "A valid client_Id and client_Secret must be provided.");
                context.Rejected();
                return;
            }
            await Task.Run(() => context.Validated(clientId));
        }
        public override async Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            Guid clientId;
            Guid.TryParse(context.ClientId, out clientId);
            //validate aginstdb or config: GetByClientId(clientId);
            bool client = ConfigurationManager.AppSettings["ClientId"] == clientId.ToString().ToUpper();
            if (!client)
            {
                context.SetError("invalid_grant", "Invaild client.");
                context.Rejected();
                return;
            }
            var claimsIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            claimsIdentity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
            await Task.Run(() => context.Validated(claimsIdentity));
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            if (context.TokenIssued)
            {
                context.Properties.ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(3600);
            }
            return Task.FromResult<object>(null);
        }
    }
}
