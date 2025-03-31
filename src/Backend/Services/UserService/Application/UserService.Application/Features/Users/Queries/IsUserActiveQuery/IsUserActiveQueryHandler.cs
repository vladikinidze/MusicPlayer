using MediatR;
using UserService.Application.Interfaces;
using UserService.Application.Interfaces.User;
using UserService.Application.Services;

namespace UserService.Application.User.Queries.IsUserActiveQuery;

public class IsUserActiveQueryHandler : IRequestHandler<User.Queries.IsUserActiveQuery.IsUserActiveQuery, bool>
{
    private readonly IUserService _userService;

    public IsUserActiveQueryHandler(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<bool> Handle(User.Queries.IsUserActiveQuery.IsUserActiveQuery request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserByIdAsync(request.UserId);
        var isActive = await _userService.IsUserActiveAsync(user);
        return isActive;
    }
}