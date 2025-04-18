using Microsoft.IdentityModel.Tokens;
using Social_Media.Models;
using System.Security.Claims;

namespace Social_Media.Repository
{
    public interface IJWTTokens
    {
        Task<string> GenerateToken(ApplicationUser User);
        Task<List<Claim>> GetClaimsOFUser(ApplicationUser User);
        SigningCredentials GetSigningCredentials();
    }
}
