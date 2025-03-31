using AutoMapper;
using MediatR;
using UserService.Application.Interfaces;
using UserService.Application.Interfaces.User;
using UserService.Application.Services;
using UserService.Application.ViewModels;

namespace UserService.Application.User.Queries.GetUsersByIdsQuery;

public class GetUsersByIdsQueryHandler : IRequestHandler<User.Queries.GetUsersByIdsQuery.GetUsersByIdsQuery, UserListViewModel>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetUsersByIdsQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<UserListViewModel> Handle(User.Queries.GetUsersByIdsQuery.GetUsersByIdsQuery request, CancellationToken cancellationToken)
    {
        var users = await _userService.GetUsersByIdAsync(request.Ids);
        var mappedUsers = _mapper.Map<IEnumerable<UserViewModel>>(users);
        return new UserListViewModel { Users = mappedUsers };
    }
}