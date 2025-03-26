using AutoMapper;
using MediatR;
using UserService.Application.Dtos;
using UserService.Application.Interfaces;

namespace UserService.Application.UseCases.Commands.LoginCommand;

public class LoginCommandHandler : IRequestHandler<LoginCommand, bool>
{
    private readonly IUserAuthenticationService _userAuthenticationService;
    private readonly IMapper _mapper;

    public LoginCommandHandler(IUserAuthenticationService userAuthenticationService, IMapper mapper)
    {
        _userAuthenticationService = userAuthenticationService;
        _mapper = mapper;
    }
    
    public async Task<bool> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var loginUserDto = _mapper.Map<LoginUserDto>(request);
        return await _userAuthenticationService.LoginUserAsync(loginUserDto);
    }
}