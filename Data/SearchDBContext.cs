using boutaburger.Models;
using Microsoft.EntityFrameworkCore;

namespace boutaburger.Data
{
    public class SearchDbContext : DbContext
    {
        public DbSet<SearchDb> SearchDb { get; set; }

        // Other DbSet properties as needed

        public SearchDbContext(DbContextOptions<SearchDbContext> options)
            : base(options)
        {
        }
    }
}
