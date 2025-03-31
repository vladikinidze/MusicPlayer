using MediatR;
using UserService.Application.Dtos;

namespace UserService.Application.User.Queries.GetUserClaimsQuery;

public class GetUserClaimsQuery : IRequest<UserClaimsDto>
{
    public string UserId { get; set; } = null!;
}