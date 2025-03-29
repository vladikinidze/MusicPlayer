using AutoMapper;
using MediatR;
using UserService.Application.Dtos;
using UserService.Application.Services;

namespace UserService.Application.UseCases.Commands.UpdateCommand;

public class UpdateCommandHandler : IRequestHandler<UpdateCommand, bool>
{
    private readonly IUserCommandService _userCommandService;
    private readonly IMapper _mapper;

    public UpdateCommandHandler(IUserCommandService userCommandService, IMapper mapper)
    {
        _userCommandService = userCommandService;
        _mapper = mapper;
    }
    
    public async Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        var registerUserDto = _mapper.Map<UpdateUserDto>(request);
        var result = await _userCommandService.UpdateUserAsync(registerUserDto);
        return result;
    }
}