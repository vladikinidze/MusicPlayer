using UserService.Application.ViewModels;
using UserService.Domain.Models;

namespace UserService.Application.Common.Mappings;

public class UserProfile : AutoMapper.Profile
{
    public UserProfile()
    {
        CreateMap<IApplicationUser, UserViewModel>()
            .ForMember(viewModel => viewModel.DisplayName, 
                options => options.MapFrom(user => user.UserName));
    }
}