using System.Security.Claims;

namespace IdentityService.Application.Requests;

public class TokenCreationDto
{
    public ClaimsPrincipal Subject { get; init; } = null!;
}