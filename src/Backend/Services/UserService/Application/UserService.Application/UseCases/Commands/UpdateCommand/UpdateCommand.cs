using MediatR;

namespace UserService.Application.UseCases.Commands.UpdateCommand;

public class UpdateCommand : IRequest<bool>
{
    public string UserName { get; set; } = null!;
}