using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FCI.CleanEgypt.Application.Core.Helpers;

public class UserUtility
    (IHttpContextAccessor httpContextAccessor)
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public string GetUserId()
    {
        if (_httpContextAccessor?.HttpContext?.User is null)
            throw new InvalidOperationException("User is not authenticated");

        var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

        return userIdClaim is not null ?
            userIdClaim.Value :
            throw new InvalidOperationException("User is not authenticated");
    }
}