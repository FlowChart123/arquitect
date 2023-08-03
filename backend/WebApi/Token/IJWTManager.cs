using Microsoft.IdentityModel.Tokens;

namespace WebApi.Token
{
    public interface IJWTManager
    {
       public JWTMAnagerRepo AddAudience(string audience);
       public JWTMAnagerRepo AddClaim(string type, string value);
       public JWTMAnagerRepo AddClaims(Dictionary<string, string> claims);
       public JWTMAnagerRepo AddExpiry(int expiryInMinutes);
       public JWTMAnagerRepo AddIssuer(string issuer);
       public JWTMAnagerRepo AddSecurityKey(SecurityKey securityKey);
       public JWTMAnagerRepo AddSubject(string subject);
       public JWTToken Builder();

        public string GenerateToken();
    }
}