using AutoMapper;
using MediatR;
using UserService.Application.Interfaces;
using UserService.Application.Interfaces.Adapters;
using UserService.Application.Interfaces.User;
using UserService.Application.Services;
using UserService.Application.ViewModels;

namespace UserService.Application.User.Queries.GetUserByIdQuery;

public class GetUserByIdQueryHandler : IRequestHandler<User.Queries.GetUserByIdQuery.GetUserByIdQuery, UserViewModel>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    public async Task<UserViewModel> Handle(User.Queries.GetUserByIdQuery.GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserByIdAsync(request.UserId);
        var userViewModel = _mapper.Map<UserViewModel>(user);
        return userViewModel;
    }
}