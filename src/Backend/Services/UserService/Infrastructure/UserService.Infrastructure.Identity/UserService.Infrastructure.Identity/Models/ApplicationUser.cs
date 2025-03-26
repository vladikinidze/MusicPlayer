using Microsoft.AspNetCore.Identity;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Identity.Models;

public class ApplicationUser : IdentityUser, IApplicationUser
{
    public DateTime RegisteredAt { get; set; }
}