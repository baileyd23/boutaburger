using boutaburger.Models;
using Microsoft.EntityFrameworkCore;

namespace boutaburger.Data
{
    public class CartItemDbContext : DbContext
    {
        public DbSet<CartItem> CartItems { get; set; }
        internal DbSet<MenuItem> MenuItems { get; set; }

        // Other DbSet properties as needed

        public CartItemDbContext(DbContextOptions<CartItemDbContext> options)
            : base(options)
        {
        }
    }
}
