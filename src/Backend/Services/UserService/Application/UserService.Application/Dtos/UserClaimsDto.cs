namespace UserService.Application.Dtos;

public record UserClaimsDto(string UserId, 
    IEnumerable<string> Roles, IEnumerable<ClaimDto> Claims);