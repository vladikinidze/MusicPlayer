using AutoMapper;
using MediatR;
using UserService.Application.Interfaces;
using UserService.Application.Interfaces.User;
using UserService.Application.Services;

namespace UserService.Application.User.Commands.RegisterCommand;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public RegisterCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    public async Task<bool> Handle(User.Commands.RegisterCommand.RegisterCommand request, CancellationToken cancellationToken)
    {
        var result = await _userService.RegisterUserAsync(null, request.Password);
        return result;
    }
}