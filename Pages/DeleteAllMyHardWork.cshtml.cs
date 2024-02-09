using boutaburger.Data;
using boutaburger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages
{
    [Authorize]
    public class DeleteAllMyHardWorkModel : PageModel
    {
        private readonly MenuItemDbContext dbContext;

        public DeleteAllMyHardWorkModel(MenuItemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //public decimal Total { get; set; }
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public void OnGet()
        {
            MenuItems = dbContext.MenuItems.ToList();
        }

        public IActionResult OnPostDelete(int id)
        {


            var itemToDelete = MenuItems.FirstOrDefault(item => item.ID == id);
            if (itemToDelete != null)
            {
                MenuItems.Remove(itemToDelete);
            }
            var dbItemToDelete = dbContext.MenuItems.Find(id);
            if (dbItemToDelete != null)
            {
                dbContext.MenuItems.Remove(dbItemToDelete);
                dbContext.SaveChanges();
            }
            return RedirectToPage("/Checkout/Checkout");
        }

    }

}
