using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Token
{
    public class JWTMAnagerRepo : IJWTManager
    {

        private readonly IConfiguration Configuration;

        #region Fields
        private SecurityKey? securityKey = null;
        private string? subject = "";
        private string? issuer = "";
        private string? audience = "";
        private int expiryInMinutes = 5;
        private Dictionary<string, string> claims = new Dictionary<string, string>();
        #endregion        

        public JWTMAnagerRepo(IConfiguration _config)
        {
            this.Configuration = _config;
            
            string? configKey = Configuration["JWT:Key"];
            string _key = configKey == null ? "" : configKey;
            var key = JWTSecurityKey.Create(_key);

            string? _subject = Configuration["JWT:Subject"];
            string? _issuer = Configuration["JWT:Issuer"];
            string? _audience = Configuration["JWT:Audience"];

            this.securityKey = key;
            this.subject = _subject;
            this.issuer = _issuer;
            this.audience = _audience;
            this.expiryInMinutes = 5;                                 
        }


        #region Assign Methods
        public JWTMAnagerRepo AddSecurityKey(SecurityKey securityKey)
        {
            this.securityKey = securityKey;
            return this;
        }

        public JWTMAnagerRepo AddSubject(string subject)
        {
            this.subject = subject;
            return this;
        }

        public JWTMAnagerRepo AddIssuer(string issuer)
        {
            this.issuer = issuer;
            return this;
        }

        public JWTMAnagerRepo AddAudience(string audience)
        {
            this.audience = audience;
            return this;
        }

        public JWTMAnagerRepo AddClaim(string type, string value)
        {
            this.claims.Add(type, value);
            return this;
        }

        public JWTMAnagerRepo AddClaims(Dictionary<string, string> claims)
        {
            this.claims.Union(claims);
            return this;
        }

        public JWTMAnagerRepo AddExpiry(int expiryInMinutes)
        {
            this.expiryInMinutes = expiryInMinutes;
            return this;
        }
        #endregion

        private void EnsureArguments()
        {
            if (this.securityKey == null)
                throw new ArgumentNullException("Security Key");

            if (string.IsNullOrEmpty(this.subject))
                throw new ArgumentNullException("Subject");

            if (string.IsNullOrEmpty(this.issuer))
                throw new ArgumentNullException("Issuer");

            if (string.IsNullOrEmpty(this.audience))
                throw new ArgumentNullException("Audience");
        }


        protected dynamic GetDetail(string token)
        {

            string? configKey = Configuration["JWT:Key"];
            string _key = configKey == null ? "" : configKey;

            string secret = _key;
            var key = Encoding.ASCII.GetBytes(secret);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(token, validations, out var tokenSecure);
            return claims.Identity;
        }

        public JWTToken Builder()
        {
            EnsureArguments();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,this.subject == null ? "sistecno":this.subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }.Union(this.claims.Select(item => new Claim(item.Key, item.Value)));

         
            var token = new JwtSecurityToken(
                issuer: this.issuer,
                audience: this.audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                signingCredentials: new SigningCredentials(
                                                   this.securityKey,
                                                   SecurityAlgorithms.HmacSha256)

                );

            
            
            return new JWTToken(token);
        }


        public string GenerateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Secret_Key-12345678");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "salinoi@gmail.com"),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }




    }
}
