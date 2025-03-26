using MediatR;
using UserService.Application.Dtos;

namespace UserService.Application.UseCases.Commands.RegisterCommand;

public class RegisterCommand : IRequest<bool>
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
}