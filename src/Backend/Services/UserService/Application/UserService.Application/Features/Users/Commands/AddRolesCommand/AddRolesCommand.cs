using MediatR;

namespace UserService.Application.User.Commands.AddRolesCommand;

public class AddRolesCommand : IRequest<Unit>
{
    public List<string> Roles { get; set; } = new();
}