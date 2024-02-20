namespace boutaburger.Pages;
using boutaburger.Data;
using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

public class EditMenuModel : PageModel
{
    private readonly MenuItemDbContext dbContext;
    public EditMenuModel(MenuItemDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [BindProperty]
    public MenuItem EditMenuItem { get; set; }

    public void OnGet(int id)
    {
        // Retrieve the item to edit from the database
        EditMenuItem = dbContext.MenuItems.Find(id);

        if (EditMenuItem == null)
        {
            // Handle the case when the item is not found
            RedirectToPage("/DeleteAllMyHardWork");
        }
    }

    public IActionResult OnPostEdit(int id, string EditedMenuItem)
    {
        var menuItem = JsonSerializer.Deserialize<MenuItem>(EditedMenuItem);

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
