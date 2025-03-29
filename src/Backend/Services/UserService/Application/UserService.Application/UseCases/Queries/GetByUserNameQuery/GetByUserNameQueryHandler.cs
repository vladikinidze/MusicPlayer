using AutoMapper;
using MediatR;
using UserService.Application.Services;
using UserService.Application.ViewModels;

namespace UserService.Application.UseCases.Queries.GetByUserNameQuery;

public class GetByUserNameQueryHandler : IRequestHandler<GetByUserNameQuery, UserViewModel>
{
    private readonly IUserQueryService _userQueryService;
    private readonly IMapper _mapper;

    public GetByUserNameQueryHandler(IUserQueryService userQueryService, IMapper mapper)
    {
        _userQueryService = userQueryService;
        _mapper = mapper;
    }
    
    public async Task<UserViewModel> Handle(GetByUserNameQuery request, CancellationToken cancellationToken)
    {
        var user = await _userQueryService.FindByEmailOrUserNameAsync(request.UserName);
        var userViewModel = _mapper.Map<UserViewModel>(user);
        return userViewModel;
    }
}