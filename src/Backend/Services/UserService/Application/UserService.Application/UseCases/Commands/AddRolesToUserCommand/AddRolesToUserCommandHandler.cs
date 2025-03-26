using AutoMapper;
using MediatR;
using UserService.Application.Dtos;
using UserService.Application.Interfaces;

namespace UserService.Application.UseCases.Commands.AddRolesToUserCommand;

public class AddRolesToUserCommandHandler : IRequestHandler<AddRolesToUserCommand, Unit>
{
    private readonly IRoleManagementService _roleManagementService;
    private readonly IMapper _mapper;

    public AddRolesToUserCommandHandler(IRoleManagementService roleManagementService, IMapper mapper)
    {
        _roleManagementService = roleManagementService;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(AddRolesToUserCommand request, CancellationToken cancellationToken)
    {
        var addRolesToUserDto = _mapper.Map<AddRolesToUserDto>(request);
        await _roleManagementService.AddRolesToUserAsync(addRolesToUserDto);
        return Unit.Value;
    }
}