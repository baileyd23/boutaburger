using boutaburger.Models;
using Microsoft.EntityFrameworkCore;
namespace boutaburger.Data;

public class MenuItemDbContext : DbContext
{
    public DbSet<MenuItem> MenuItems { get; set; }

    // Other DbSet properties as needed

    public MenuItemDbContext(DbContextOptions<MenuItemDbContext> options)
        : base(options)
    {
    }
}