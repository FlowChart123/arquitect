using System.IdentityModel.Tokens.Jwt;

namespace WebApi.Token
{
    public class JWTToken
    {
        private JwtSecurityToken token;

        internal JWTToken(JwtSecurityToken token)
        {
            this.token = token;
        }

        public DateTime ValidTo => token.ValidTo;

        public string value => new JwtSecurityTokenHandler().WriteToken(this.token);
    }
}
