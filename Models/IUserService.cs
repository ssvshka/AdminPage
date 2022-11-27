using System.Security.Claims;

namespace Authemption.Models
{
    public interface IUserService
    {
        List<ApplicationUser> GetUsers();
        Task BlockUser(ApplicationUser user);
        Task UnblockUser(ApplicationUser user);
        Task DeleteUser(ApplicationUser user);
        Task SignOutUser(ApplicationUser user);
    }
}
