using Authemption.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authemption.Data
{
    public class UserDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly DbContextOptions _options;

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}