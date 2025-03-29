using AutoMapper;
using MediatR;
using UserService.Application.Dtos;
using UserService.Application.Services;

namespace UserService.Application.UseCases.Commands.RegisterCommand;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
{
    private readonly IUserRegistrationService _userRegistrationService;
    private readonly IMapper _mapper;

    public RegisterCommandHandler(IUserRegistrationService userRegistrationService, IMapper mapper)
    {
        _userRegistrationService = userRegistrationService;
        _mapper = mapper;
    }
    
    public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var registerUserDto = _mapper.Map<RegisterUserDto>(request);
        var result = await _userRegistrationService.RegisterUserAsync(registerUserDto);
        return result;
    }
}