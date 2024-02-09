using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using boutaburger.Models;
using boutaburger.Data;

namespace boutaburger.Pages
{
    public class addMenuModel : PageModel
    {
        private readonly MenuItemDbContext dbContext;
        public addMenuModel(MenuItemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty] 
        public MenuItem addMenuItem { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            var menuDomain = new MenuItem
            {
                Name = addMenuItem.Name,
                Price = addMenuItem.Price,
                Description = addMenuItem.Description,
                Pics = addMenuItem.Pics,
            };

            dbContext.MenuItems.Add(menuDomain);
            dbContext.SaveChanges();

            ViewData["Message"] = "Added";
        }
    }
}
