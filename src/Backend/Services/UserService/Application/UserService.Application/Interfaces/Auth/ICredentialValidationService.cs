using UserService.Application.Common.Results;

namespace UserService.Application.Interfaces.Auth;

public interface ICredentialValidationService
{
    Task<Result<bool>> ValidatePasswordAsync(string login, string password);
}