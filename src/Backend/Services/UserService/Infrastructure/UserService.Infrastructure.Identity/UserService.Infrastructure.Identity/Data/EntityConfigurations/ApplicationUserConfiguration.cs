using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Infrastructure.Identity.Models;

namespace UserService.Infrastructure.Identity.EntityConfigurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasKey(user => user.Id);
        builder.HasIndex(user => user.NormalizedEmail);
        builder.HasIndex(user => user.NormalizedUserName);
    }
}