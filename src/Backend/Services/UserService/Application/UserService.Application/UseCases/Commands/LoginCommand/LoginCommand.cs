using MediatR;

namespace UserService.Application.UseCases.Commands.LoginCommand;

public class LoginCommand : IRequest<bool>
{
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
}