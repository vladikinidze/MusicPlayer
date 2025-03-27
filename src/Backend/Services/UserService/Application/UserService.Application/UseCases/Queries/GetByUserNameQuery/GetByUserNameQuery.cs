using MediatR;
using UserService.Application.ViewModels;

namespace UserService.Application.UseCases.Queries.GetByUserNameQuery;

public class GetByUserNameQuery : IRequest<UserViewModel>
{
    public string UserName { get; set; } = null!;
}