using MediatR;
using UserService.Application.ViewModels;

namespace UserService.Application.User.Queries.GetUsersByIdsQuery;

public class GetUsersByIdsQuery : IRequest<UserListViewModel>
{
    public List<string> Ids { get; set; } = new();
}