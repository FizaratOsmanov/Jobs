using Microsoft.AspNetCore.Identity;
namespace CORE.Models;
public class AppUser:IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhotoPath { get; set; }
    public string? Profession { get; set; }
    public string? Address { get; set; }
    public string? Country { get; set; }
    public ICollection<Comment> Comments { get; set; }
}
