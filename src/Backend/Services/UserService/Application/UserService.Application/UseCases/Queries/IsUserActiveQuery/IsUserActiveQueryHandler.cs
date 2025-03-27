using MediatR;
using UserService.Application.Interfaces;

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
        return await _userStatusService.IsUserActiveAsync(request.UserId);
    }
}