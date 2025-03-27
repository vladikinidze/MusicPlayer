using MediatR;
using UserService.Application.ViewModels;

namespace UserService.Application.UseCases.Queries.GetUserByIdQuery;

public class GetUserByIdQuery : IRequest<UserViewModel>
{
    public string UserId { get; set; } = null!;
}