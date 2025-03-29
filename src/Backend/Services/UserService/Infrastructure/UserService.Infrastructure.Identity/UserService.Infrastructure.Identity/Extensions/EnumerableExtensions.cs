using Microsoft.AspNetCore.Identity;
using UserService.Application.Constants;
using UserService.Application.ViewModels;

namespace UserService.Infrastructure.Identity.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<ErrorViewModel> ToErrorViewModels(this IEnumerable<IdentityError> identityErrors)
    {
        return identityErrors
            .Select(error => new ErrorViewModel(ErrorConstants.EmptyPropertyName, error.Description));
    }
}