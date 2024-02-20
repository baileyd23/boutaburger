using boutaburger.Data;
using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
 
    public class editMenuModel : PageModel
    {
        private readonly MenuItemDbContext dbContext;
        public editMenuModel(MenuItemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public MenuItem editMenuItem { get; set; }

        public IActionResult OnGet(int id)
        {
            editMenuItem = dbContext.MenuItems.Find(id);

            if (editMenuItem == null)
            {
                return RedirectToPage("/DeleteAllMyHardWork"); // or handle the case when the item is not found
            }

            return Page();
        }

        public IActionResult OnPostSave()
        {
            if (ModelState.IsValid)
            {
                // Update the existing menu item in the database
                var existingItem = dbContext.MenuItems.Find(editMenuItem.ID);

                if (existingItem != null)
                {
                    existingItem.Name = editMenuItem.Name;
                    existingItem.Description = editMenuItem.Description;
                    existingItem.Pics = editMenuItem.Pics;
                    existingItem.Price = editMenuItem.Price;

                    dbContext.SaveChanges();
                }

                TempData["Message"] = "Added";
            }

            return RedirectToPage("/DeleteAllMyHardWork");
        }
    }
}