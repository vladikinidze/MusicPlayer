using MediatR;

namespace UserService.Application.User.Commands.AddRolesToUserCommand;

public class AddRolesToUserCommand : IRequest<Unit>
{
    public string UserId { get; set; } = null!;
    public List<string> Roles { get; set; } = new();
}