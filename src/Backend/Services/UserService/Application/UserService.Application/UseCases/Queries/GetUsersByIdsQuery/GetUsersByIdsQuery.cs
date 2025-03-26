using MediatR;
using UserService.Application.ViewModels;

namespace UserService.Application.UseCases.Queries.GetUsersByIdsQuery;

public class GetUsersByIdsQuery : IRequest<UsersViewModel>
{
    public List<string> Ids { get; set; } = new();
}