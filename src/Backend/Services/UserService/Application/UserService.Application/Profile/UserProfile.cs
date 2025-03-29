using UserService.Application.Dtos;
using UserService.Application.UseCases.Commands.AddRolesToUserCommand;
using UserService.Application.UseCases.Commands.LoginCommand;
using UserService.Application.UseCases.Commands.RegisterCommand;
using UserService.Application.UseCases.Commands.UpdateCommand;
using UserService.Application.ViewModels;
using UserService.Domain.Models;

namespace UserService.Application.Profile;

public class UserProfile : AutoMapper.Profile
{
    public UserProfile()
    {
        CreateMap<IApplicationUser, UserViewModel>()
            .ForMember(viewModel => viewModel.DisplayName, 
                options => options.MapFrom(user => user.UserName));

        CreateMap<LoginCommand, LoginUserDto>();
        CreateMap<RegisterCommand, RegisterUserDto>();
        CreateMap<UpdateCommand, UpdateUserDto>();
        CreateMap<AddRolesToUserCommand, AddRolesToUserDto>();
    }
}