using MediatR;
using UserService.Application.Interfaces;
using UserService.Application.Interfaces.User;
using UserService.Application.Services;

namespace UserService.Application.User.Commands.UpdateCommand;

public class UpdateCommandHandler : IRequestHandler<User.Commands.UpdateCommand.UpdateCommand, bool>
{
    private readonly IUserService _userService;

    public UpdateCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<bool> Handle(User.Commands.UpdateCommand.UpdateCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserByIdAsync(request.UserId);
        user.UserName = request.UserName;
        var result = await _userService.UpdateUserAsync(user);
        return result;
    }
}