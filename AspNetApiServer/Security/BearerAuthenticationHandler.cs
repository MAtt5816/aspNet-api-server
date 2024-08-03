using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AspNetApiServer.Security
{
    /// <summary>
    /// class to handle bearer authentication.
    /// </summary>
    public class BearerAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        /// <summary>
        /// scheme name for authentication handler.
        /// </summary>
        public const string SchemeName = "Bearer";

        public BearerAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        /// <summary>
        /// verify that require authorization header exists.
        /// </summary>
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing Authorization Header");
            }

            Models.User? user;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var bearer = authHeader.Scheme;
                var token = authHeader.Parameter ?? String.Empty;

                user = Helpers.JwtHelper.CheckJwtToken(token);
                if (bearer != "Bearer" || user == null)
                    return AuthenticateResult.Fail("Invalid Authorization Header");
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            var claims = new[] {
                new Claim("id", user?.Id.ToString() ?? String.Empty),
                new Claim(ClaimTypes.Name, user?.Username ?? String.Empty),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
