using boutaburger.Models;
using Microsoft.EntityFrameworkCore;

namespace boutaburger.Data
{
    public class UserAccountDbContext : DbContext
    {
        public DbSet<UserAccount> Accounts { get; set; }

        // Other DbSet properties as needed

        public UserAccountDbContext(DbContextOptions<UserAccountDbContext> options)
            : base(options)
        {
        }
    }
}