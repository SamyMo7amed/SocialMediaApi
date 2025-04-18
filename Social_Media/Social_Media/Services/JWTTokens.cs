using Microsoft.IdentityModel.Tokens;
using Social_Media.Models;
using Social_Media.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Social_Media.Services
{
    public class JWTTokens : IJWTTokens
    {
        IUnitOFWork UnitOFWork;
        IConfiguration Configuration;
        public JWTTokens(IUnitOFWork UnitOFWork, IConfiguration configuration)
        {
            this.UnitOFWork = UnitOFWork;
            Configuration = configuration;
        }

        public async Task<List<Claim>> GetClaimsOFUser(ApplicationUser User)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, User.FirstName+" "+User.LastName));
            claims.Add(new Claim(ClaimTypes.Email, User.Email));            
            claims.Add(new Claim(ClaimTypes.NameIdentifier, User.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            IList<string> Roles =await UnitOFWork.UserManager.GetRolesAsync(User);
            foreach(var Role in Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, Role));
            }
            return claims;
        }
        public SigningCredentials GetSigningCredentials()
        {
            SymmetricSecurityKey Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]));
            SigningCredentials SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256) { };
            return SigningCredentials;
        }
        //To Get The Token OF User
        public async Task<string> GenerateToken(ApplicationUser User)
        {
            JwtSecurityToken MyToken = new JwtSecurityToken(
                issuer: Configuration["JWT:Issuer"],
                audience: Configuration["JWT:Audience"],
                expires: DateTime.Now.AddDays(Configuration.GetValue<int>("JWT:ExpiredON")),
                signingCredentials: GetSigningCredentials(),
                claims: await GetClaimsOFUser(User)
                );
            string Token = new JwtSecurityTokenHandler().WriteToken(MyToken);
            return Token;

        }
        
    }
}
