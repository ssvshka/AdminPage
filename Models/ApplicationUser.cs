using Microsoft.AspNetCore.Identity;

namespace Authemption.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public bool Active { get; set; } = true;
        public string? Name { get; set; }
    }
}
