using ChatServerApi.Domain.Entity;
using ChatServerApi.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using AuthenticationService.Options;
using System.Text;

namespace AuthenticationService.Security.Token
{
    public class TokenJwtHmacSha256 : IToken
    {
        IOptions<OptionsJwtSecret> config;
        public TokenJwtHmacSha256(IOptions<OptionsJwtSecret> config)
        {
            this.config = config;
        }

        public string Get(IdentificationEntity user)
        {
            string roles = string.Empty;
            List<Claim> claims = new List<Claim> {
                                             new Claim(ClaimsIdentity.DefaultIssuer, config.Value.Issuer),
                                             new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                                             new Claim("user_id", user.UserId.ToString()),
                                             new Claim("tag-name", user.TagName.ToString())
            };
            for (int i = 0; i < user.Roles.Count; ++i)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Roles[i]));
            }
            JwtSecurityToken jwt = new JwtSecurityToken(
            issuer: config.Value.Issuer,
            audience: config.Value.Audience,
            claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)), // время действия 60 минуты
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Value.Key)), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
