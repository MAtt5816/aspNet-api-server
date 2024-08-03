using System.Data.Entity.Core;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AspNetApiServer.DB;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AspNetApiServer.Security
{
    /// <summary>
    /// class to handle basic authentication.
    /// </summary>
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        /// <summary>
        /// scheme name for authentication handler.
        /// </summary>
        public const string SchemeName = "Basic";

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        /// <summary>
        /// verify that require authorization header exists and handle decode data.
        /// </summary>
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing Authorization Header");
            }

            Models.User? userFromDb;
            
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];

                await using var db = new StudentDataContext();
                try
                {
                    userFromDb = db.Users.Where(u => u.Username == username).SingleOrDefault();
                
                    var crypt = SHA256.Create();
                    var hash = new System.Text.StringBuilder();
                    byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password + userFromDb?.Salt));
                    foreach (byte theByte in crypto)
                    {
                        hash.Append(theByte.ToString("x2"));
                    }
                    var passHash = hash.ToString();
                
                    if (passHash != userFromDb?.Sha256)
                    {
                        return AuthenticateResult.Fail("Invalid Authorization Credentials");
                    }

                    Helpers.JwtHelper.Id = userFromDb.Id.ToString();
                    Helpers.JwtHelper.Username = userFromDb.Username;
                }
                catch(EntityException e)
                {
                    return AuthenticateResult.Fail("Database connection error: " + e.Message);
                }
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            var claims = new[] {
                new Claim("id", userFromDb.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromDb.Username),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
