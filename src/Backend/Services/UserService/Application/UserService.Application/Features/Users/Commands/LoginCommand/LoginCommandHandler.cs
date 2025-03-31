using AutoMapper;
using MediatR;
using UserService.Application.Interfaces;
using UserService.Application.Interfaces.User;
using UserService.Application.Services;

namespace UserService.Application.User.Commands.LoginCommand;

public class LoginCommandHandler : IRequestHandler<User.Commands.LoginCommand.LoginCommand, bool>
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public LoginCommandHandler(IAuthService authService, IUserService userService, IMapper mapper)
    {
        _authService = authService;
        _userService = userService;
        _mapper = mapper;
    }
    
    public async Task<bool> Handle(User.Commands.LoginCommand.LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetByEmailOrUserNameAsync(request.Login);
        var result = await _authService.LoginUserAsync(user, request.Password);
        return result;
    }
}