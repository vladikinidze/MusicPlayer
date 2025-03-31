using UserService.Domain.Models;
using UserService.Infrastructure.Identity.Models;

namespace UserService.Infrastructure.Identity.Interfaces;

public interface IUserCaster
{
    public bool TryCast(IApplicationUser domainUser, out ApplicationUser? user);
    public ApplicationUser CastToApplicationUser(IApplicationUser domainUser);
}