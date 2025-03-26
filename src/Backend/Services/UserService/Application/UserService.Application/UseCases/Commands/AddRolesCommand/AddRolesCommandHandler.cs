using MediatR;
using UserService.Application.Interfaces;

namespace UserService.Application.UseCases.Commands.AddRolesCommand;

public class AddRolesCommandHandler : IRequestHandler<AddRolesCommand, Unit>
{
    private readonly IRoleManagementService _roleManagementService;

    public AddRolesCommandHandler(IRoleManagementService roleManagementService)
    {
        _roleManagementService = roleManagementService;
    }
    
    public async Task<Unit> Handle(AddRolesCommand request, CancellationToken cancellationToken)
    {
        await _roleManagementService.AddRolesAsync(request.Roles);
        return Unit.Value;
    }
}