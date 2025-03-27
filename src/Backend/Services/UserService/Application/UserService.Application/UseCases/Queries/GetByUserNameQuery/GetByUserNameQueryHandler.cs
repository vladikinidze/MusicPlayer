using AutoMapper;
using MediatR;
using UserService.Application.Interfaces;
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
        var result = await _userQueryService.FindByEmailOrUserNameAsync(request.UserName);
        var user = _mapper.Map<UserViewModel>(result);
        return user;
    }
}