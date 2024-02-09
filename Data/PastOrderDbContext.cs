using boutaburger.Models;
using Microsoft.EntityFrameworkCore;

namespace boutaburger.Data
{
    public class PastOrderDbContext : DbContext
    {
        public DbSet<PastOrder> PastOrders { get; set; }

        // Other DbSet properties as needed

        public PastOrderDbContext(DbContextOptions<PastOrderDbContext> options)
            : base(options)
        {
        }
    }
}