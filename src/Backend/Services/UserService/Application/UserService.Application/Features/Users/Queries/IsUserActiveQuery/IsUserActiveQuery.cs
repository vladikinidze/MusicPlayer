using MediatR;

namespace UserService.Application.User.Queries.IsUserActiveQuery;

public class IsUserActiveQuery : IRequest<bool>
{
    public string UserId { get; set; } = null!;
}