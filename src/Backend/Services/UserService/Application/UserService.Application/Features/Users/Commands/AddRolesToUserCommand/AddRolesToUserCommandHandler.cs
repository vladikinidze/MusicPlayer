using MediatR;
using UserService.Application.Dtos;
using UserService.Application.Interfaces;
using UserService.Application.Interfaces.Roles;
using UserService.Application.Interfaces.User;
using UserService.Application.Services;

namespace UserService.Application.User.Commands.AddRolesToUserCommand;

public class AddRolesToUserCommandHandler : IRequestHandler<User.Commands.AddRolesToUserCommand.AddRolesToUserCommand, Unit>
{
    private readonly IRoleService _roleService;
    private readonly IUserService _userService;

    public AddRolesToUserCommandHandler(IRoleService roleService, 
        IUserService userService)
    {
        _roleService = roleService;
        _userService = userService;
    }
    
    public async Task<Unit> Handle(User.Commands.AddRolesToUserCommand.AddRolesToUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserByIdAsync(request.UserId);
        var addRolesToUserDto = new AddRolesToUserDto(user, request.Roles);
        await _roleService.AddRolesToUserAsync(addRolesToUserDto);
        return Unit.Value;
    }
}