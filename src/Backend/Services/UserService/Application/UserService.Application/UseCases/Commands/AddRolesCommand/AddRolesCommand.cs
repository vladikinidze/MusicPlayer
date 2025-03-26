using MediatR;

namespace UserService.Application.UseCases.Commands.AddRolesCommand;

public class AddRolesCommand : IRequest<Unit>
{
    public List<string> Roles { get; set; } = new();
}