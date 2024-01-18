using boutaburger.Models;
using Microsoft.EntityFrameworkCore;
namespace boutaburger.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BurgerOrder> BurgerOrders { get; set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
    }
}
