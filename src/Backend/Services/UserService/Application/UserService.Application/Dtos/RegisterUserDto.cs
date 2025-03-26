namespace UserService.Application.Dtos;

public record RegisterUserDto(string UserName, string Email, 
    string Password, string ConfirmPassword);
