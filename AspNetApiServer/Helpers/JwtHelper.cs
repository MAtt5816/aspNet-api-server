using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AspNetApiServer.DB;
using Microsoft.IdentityModel.Tokens;

namespace AspNetApiServer.Helpers;

public static class JwtHelper
{
    /// <summary>
    /// Last user ID for JWT token generation
    /// </summary>
    public static string Id { get; set; } = string.Empty;

    /// <summary>
    /// Last user name for JWT token generation
    /// </summary>
    public static string Username { get; set; } = string.Empty;

    /// <summary>
    /// Generate JWT token
    /// </summary>
    /// <returns>JWT token string</returns>
    public static string GenerateToken()
    {
        var jwtKey = System.Configuration.ConfigurationManager.AppSettings["jwtKey"];
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        
        var tokenHandler = new JwtSecurityTokenHandler(); 
        var tokenDescriptor = new SecurityTokenDescriptor 
        { 
            Subject = new ClaimsIdentity(new Claim[] 
            { 
                new Claim("id", Id),
                new Claim("name", Username)
            }), 

            Expires = DateTime.Now.AddHours(3), 
            SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature) 

        }; 

        var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor); 
        return tokenHandler.WriteToken(token);
    }

    public static Models.User? CheckJwtToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtKey = System.Configuration.ConfigurationManager.AppSettings["jwtKey"];
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        
        var validationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = securityKey
        };

        try
        {
            handler.ValidateToken(token, validationParameters, out _);
        }
        catch (Exception)
        {
            return null;
        }

        var securityToken = handler.ReadJwtToken(token);    
        var claims = securityToken.Claims.Select(claim => (claim.Type, claim.Value)).ToList();
        
        var id = claims.SingleOrDefault(c => c.Type == "id").Value;
        var name = claims.SingleOrDefault(c => c.Type == "name").Value;
        
        using var db = new StudentDataContext();
        Models.User? user = db.Users.Where(u => u.Id.ToString() == id).FirstOrDefault();

        if (name == user?.Username)
            return user;
        return null;
    }
}