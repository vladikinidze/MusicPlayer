using IdentityService.Application.Requests;

namespace IdentityService.Application.Services;

public interface ITokenService
{
    Task CreateIdentityTokenAsync(TokenCreationRequest tokenCreationRequest);
    Task CreateAccessTokenAsync(TokenCreationRequest tokenCreationRequest);
}