using MediatR;
using UserService.Application.Exceptions;
using UserService.Application.Services;

namespace UserService.Application.UseCases.Queries.IsUserActiveQuery;

public class IsUserActiveQueryHandler : IRequestHandler<IsUserActiveQuery, bool>
{
    private readonly IUserStatusService _userStatusService;

    public IsUserActiveQueryHandler(IUserStatusService userStatusService)
    {
        _userStatusService = userStatusService;
    }
    
    public async Task<bool> Handle(IsUserActiveQuery request, CancellationToken cancellationToken)
    {
        var isActive = await _userStatusService.IsUserActiveAsync(request.UserId);
        return isActive;
    }
}