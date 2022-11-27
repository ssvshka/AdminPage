using Authemption.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
namespace Authemption.Models
{
    public class UserService : IUserService
    {
        private UserDbContext _db;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ClaimsPrincipal? _currentUser;
        public UserService(UserDbContext db, 
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public List<ApplicationUser> GetUsers()
        {
            return _db.Users.ToList();
        }

        public async Task BlockUser(ApplicationUser user)
        {
            user.Active = false;    
            var lockoutEndDate = new DateTime(2999, 01, 01);
            await _userManager.SetLockoutEnabledAsync(user, true);
            await _userManager.SetLockoutEndDateAsync(user, lockoutEndDate);
        }

        public async Task UnblockUser(ApplicationUser user)
        {
            user.Active = true;
            await _userManager.SetLockoutEnabledAsync(user, false);
        }
        
        public async Task DeleteUser(ApplicationUser user)
        {
            await _userManager.DeleteAsync(user);
        }

        public async Task SignOutUser(ApplicationUser user)
        {
            await _userManager.UpdateSecurityStampAsync(user);
        }
    }
}
