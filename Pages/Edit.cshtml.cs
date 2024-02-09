using boutaburger.Data;
using boutaburger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Immutable;

namespace boutaburger.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly MenuItemDbContext dbContext;

        public EditModel(MenuItemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [BindProperty]
        public MenuItem EditThis { get; set; }
        public IActionResult OnGet(int? ID)
        {
            Console.WriteLine($"ID received: {ID}");
            EditThis = dbContext.MenuItems.Find(ID);
            return Page();
        }

        public void OnPost()
        {
            var existingItem = dbContext.MenuItems.Find(EditThis.ID);
            

            if (existingItem != null)
            {
                existingItem.Name = EditThis.Name;
                existingItem.Price = EditThis.Price;
                existingItem.Description = EditThis.Description;
                existingItem.Pics ="~/images/" + EditThis.Pics;

                dbContext.SaveChanges();

                ViewData["Message"] = "Updated";
            }
        }
    }
}