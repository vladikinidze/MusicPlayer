using UserService.Domain.Models;
using UserService.Infrastructure.Identity.Interfaces;
using UserService.Infrastructure.Identity.Models;

namespace UserService.Infrastructure.Identity.Adapters;

internal class UserCaster : IUserCaster
{
    public bool TryCast(IApplicationUser domainUser, out ApplicationUser? user)
    {
        user = domainUser as ApplicationUser;
        return user != null;
    }

    public ApplicationUser CastToApplicationUser(IApplicationUser domainUser)
    {
        ArgumentNullException.ThrowIfNull(nameof(domainUser));
        
        if (domainUser is ApplicationUser user)
        {
            return user;
        }
      
        throw new InvalidCastException(
            $"Expected user of type {typeof(ApplicationUser).FullName}, " + 
            $"but received {domainUser.GetType().FullName}");
    }
}