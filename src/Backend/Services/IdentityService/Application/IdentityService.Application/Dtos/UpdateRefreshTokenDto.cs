using IdentityService.Domain.Models;

namespace IdentityService.Application.Dtos;

public class RefreshTokenUpdateDto
{
    public Client Client { get; set; } = null!;
    public string Token { get; set; } = null!;
}