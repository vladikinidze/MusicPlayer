using System.ComponentModel.DataAnnotations;

namespace IdentityService.Models;

public class LoginViewModel
{
    [Required]
    public string Login { get; set; } = null!;
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    
    public string ReturnUrl { get; set; } = null!;
}