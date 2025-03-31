using MediatR;
using UserService.Application.Interfaces;
using UserService.Application.Interfaces.Roles;
using UserService.Application.Services;

namespace UserService.Application.User.Commands.AddRolesCommand;

public class AddRolesCommandHandler : IRequestHandler<User.Commands.AddRolesCommand.AddRolesCommand, Unit>
{
    private readonly IRoleService _roleService;

    public AddRolesCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }
    
    public async Task<Unit> Handle(User.Commands.AddRolesCommand.AddRolesCommand request, CancellationToken cancellationToken)
    {
        await _roleService.AddRolesAsync(request.Roles);
        return Unit.Value;
    }
}