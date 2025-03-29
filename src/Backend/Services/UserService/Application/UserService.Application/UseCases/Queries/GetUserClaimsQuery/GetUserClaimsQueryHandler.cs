using MediatR;
using UserService.Application.Dtos;
using UserService.Application.Services;

namespace UserService.Application.UseCases.Queries.GetUserClaimsQuery;

public class GetUserClaimsQueryHandler : IRequestHandler<GetUserClaimsQuery, UserClaimsDto>
{
    private readonly IUserClaimsService _userClaimsService;

    public GetUserClaimsQueryHandler(IUserClaimsService userClaimsService)
    {
        _userClaimsService = userClaimsService;
    }
    
    public async Task<UserClaimsDto> Handle(GetUserClaimsQuery request, CancellationToken cancellationToken)
    {
        var userClaimsDto = await _userClaimsService.GetUserClaimsAsync(request.UserId);
        return userClaimsDto;
    }
}