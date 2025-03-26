using MediatR;

namespace UserService.Application.UseCases.Queries.IsUserActiveQuery;

public class IsUserActiveQuery : IRequest<bool>
{
    public string UserId { get; set; } = null!;
}