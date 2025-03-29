using IdentityService.Domain.Models;

namespace IdentityService.Application.Dtos;

public class RefreshTokenCreationDto
{
    public Client Client { get; set; } = null!;
    public string UserId { get; set; } = null!;
}