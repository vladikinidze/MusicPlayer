using MediatR;

namespace UserService.Application.User.Commands.UpdateCommand;

public class UpdateCommand : IRequest<bool>
{
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;
}