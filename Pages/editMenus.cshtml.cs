using boutaburger.Data;
using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages;

    public class EditMenusModel : PageModel
    {
        private readonly MenuItemDbContext dbContext;
    public EditMenusModel(MenuItemDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [BindProperty]
        public MenuItem EditMenuItem { get; set; }

        public IActionResult OnGet(int id)
        {
            EditMenuItem = dbContext.MenuItems.Find(id);

            if (EditMenuItem == null)
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
                var existingItem = dbContext.MenuItems.Find(EditMenuItem.ID);

                if (existingItem != null)
                {
                    existingItem.Name = EditMenuItem.Name;
                    existingItem.Description = EditMenuItem.Description;
                    existingItem.Pics = EditMenuItem.Pics;
                    existingItem.Price = EditMenuItem.Price;

                    dbContext.SaveChanges();
                }

                TempData["Message"] = "Added";
            }

            return RedirectToPage("/DeleteAllMyHardWork");
        }
    }
