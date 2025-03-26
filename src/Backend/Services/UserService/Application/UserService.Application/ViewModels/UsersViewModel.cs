namespace UserService.Application.ViewModels;

public class UsersViewModel
{
    public IEnumerable<UserViewModel> Users { get; set; } = null!;
}