using AutoMapper;
using MediatR;
using UserService.Application.Services;
using UserService.Application.ViewModels;

namespace UserService.Application.UseCases.Queries.GetUsersByIdsQuery;

public class GetUsersByIdsQueryHandler : IRequestHandler<GetUsersByIdsQuery, UsersViewModel>
{
    private readonly IUserQueryService _userQueryService;
    private readonly IMapper _mapper;

    public GetUsersByIdsQueryHandler(IUserQueryService userQueryService, IMapper mapper)
    {
        _userQueryService = userQueryService;
        _mapper = mapper;
    }

    public async Task<UsersViewModel> Handle(GetUsersByIdsQuery request, CancellationToken cancellationToken)
    {
        var users = await _userQueryService.FindUsersByIdAsync(request.Ids);
        var mappedUsers = _mapper.Map<IEnumerable<UserViewModel>>(users);
        return new UsersViewModel { Users = mappedUsers };
    }
}