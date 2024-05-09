using System.Security.Claims;

namespace FCI.CleanEgypt.Contracts.Authentication.Jwt;

public interface IJwtProvider
{
    string CreateToken(List<Claim> claims);
}