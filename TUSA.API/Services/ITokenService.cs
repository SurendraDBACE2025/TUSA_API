using TUSA.Core.Result;
using System.Collections.Generic;
using System.Security.Claims;

namespace TUSA.API.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        Result<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
    }
}
