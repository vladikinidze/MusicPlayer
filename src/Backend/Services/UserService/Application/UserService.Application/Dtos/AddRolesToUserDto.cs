using UserService.Domain.Models;

namespace UserService.Application.Dtos;

public record AddRolesToUserDto(IApplicationUser User, IEnumerable<string> Roles);