namespace UserService.Domain.Models;

public interface IApplicationUser
{   
    public string Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public DateTime RegisteredAt { get; set; }
}