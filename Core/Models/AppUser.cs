using Microsoft.AspNetCore.Identity;

namespace CORE.Models
{
    public class AppUser:IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ImgPath { get; set; }
    }
}
