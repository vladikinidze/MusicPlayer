using IdentityService.Application.Requests;
using IdentityService.Domain.Models;

namespace IdentityService.Application.Services;

public interface IRefreshTokenService
{
    Task ValidateRefreshTokenAsync(string refreshToken, Client client);
    Task CreateRefreshTokenAsync(RefreshTokenCreationRequest refreshTokenCreationRequest);
    Task UpdateRefreshTokenAsync(RefreshTokenUpdateRequest refreshTokenUpdateRequest);
}