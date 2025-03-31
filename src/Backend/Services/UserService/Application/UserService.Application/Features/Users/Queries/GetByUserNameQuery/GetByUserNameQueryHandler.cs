using AutoMapper;
using MediatR;
using UserService.Application.Interfaces;
using UserService.Application.Interfaces.User;
using UserService.Application.Services;
using UserService.Application.ViewModels;

namespace UserService.Application.User.Queries.GetByUserNameQuery;

public class GetByUserNameQueryHandler : IRequestHandler<User.Queries.GetByUserNameQuery.GetByUserNameQuery, UserViewModel>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetByUserNameQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    public async Task<UserViewModel> Handle(User.Queries.GetByUserNameQuery.GetByUserNameQuery request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetByEmailOrUserNameAsync(request.UserName);
        var userViewModel = _mapper.Map<UserViewModel>(user);
        return userViewModel;
    }
}