using MediatR;
using UserService.Application.Dtos;
using UserService.Application.Interfaces;
using UserService.Application.Interfaces.Adapters;
using UserService.Application.Interfaces.User;
using UserService.Application.Services;
using UserService.Domain.Models;

namespace UserService.Application.User.Queries.GetUserClaimsQuery;

public class GetUserClaimsQueryHandler : IRequestHandler<User.Queries.GetUserClaimsQuery.GetUserClaimsQuery, UserClaimsDto>
{
    private readonly IUserService _userService;

    public GetUserClaimsQueryHandler(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<UserClaimsDto> Handle(User.Queries.GetUserClaimsQuery.GetUserClaimsQuery request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserByIdAsync(request.UserId);
        var userClaimsDto = await _userService.GetUserClaimsAsync(user);
        return userClaimsDto;
    }
}