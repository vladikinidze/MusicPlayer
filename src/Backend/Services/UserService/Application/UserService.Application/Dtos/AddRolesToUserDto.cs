namespace UserService.Application.Dtos;

public record AddRolesToUserDto(string UserId, IEnumerable<string> Roles);