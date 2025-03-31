using UserService.Application.Common.Results;
using UserService.Application.Interfaces.Auth;

namespace UserService.Infrastructure.Identity.Services.Auth;

public class CredentialValidationService : ICredentialValidationService
{
    public async Task<Result<bool>> ValidatePasswordAsync(string login, string password)
    {
        throw new NotImplementedException();
    }
}