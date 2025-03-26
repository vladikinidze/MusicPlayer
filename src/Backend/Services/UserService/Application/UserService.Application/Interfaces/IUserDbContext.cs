namespace UserService.Application.Interfaces;

public interface IUserDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}