using AutoMapper;
using MediatR;
using UserService.Application.Interfaces;
using UserService.Application.ViewModels;

namespace UserService.Application.UseCases.Queries.GetUserByIdQuery;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
{
    private readonly IUserQueryService _userQueryService;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUserQueryService userQueryService, IMapper mapper)
    {
        _userQueryService = userQueryService;
        _mapper = mapper;
    }
    
    public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var users = await _userQueryService.FindUserByIdAsync(request.UserId);
        var userViewModel = _mapper.Map<UserViewModel>(users);
        return userViewModel;
    }
}