using boutaburger.Data;
using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

public class editMenuModel : PageModel
{
    private readonly MenuItemDbContext dbContext;
    public editMenuModel(MenuItemDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [BindProperty]
    public MenuItem editMenuItem { get; set; }

    public void OnGet(int id)
    {
        // Retrieve the item to edit from the database
        editMenuItem = dbContext.MenuItems.Find(id);

        if (editMenuItem == null)
        {
            // Handle the case when the item is not found
            RedirectToPage("/DeleteAllMyHardWork");
        }
    }

    public IActionResult OnPostEdit(int id, string editedMenuItem)
    {
        var menuItem = JsonSerializer.Deserialize<MenuItem>(editedMenuItem);

        var existingItem = dbContext.MenuItems.Find(id);

        if (existingItem != null)
        {
            existingItem.Name = menuItem.Name;
            existingItem.Description = menuItem.Description;
            existingItem.Pics = menuItem.Pics;
            existingItem.Price = menuItem.Price;

            dbContext.SaveChanges();
        }

        // Redirect to Checkout or any other desired page
        return RedirectToPage("/Checkout/Checkout");
    }
}
