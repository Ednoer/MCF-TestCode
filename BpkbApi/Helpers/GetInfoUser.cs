using System.Security.Claims;

public static class ClaimsPrincipalExtensions
{
    public static string GetUserName(this ClaimsPrincipal user)
    {
        return user?.FindFirst(ClaimTypes.Name)?.Value;
    }
}
