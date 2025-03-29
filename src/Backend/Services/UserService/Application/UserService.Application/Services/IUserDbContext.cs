namespace UserService.Application.Services;

public interface IUserDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}