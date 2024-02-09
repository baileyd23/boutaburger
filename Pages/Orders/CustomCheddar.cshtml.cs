using boutaburger.Data;
using boutaburger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    [Authorize]
    public class CustomCheddarModel : PageModel
    {
        private readonly CartItemDbContext dbContext;
        private readonly MenuItemDbContext menuItemDbContext;

        public CustomCheddarModel(CartItemDbContext dbContext, MenuItemDbContext menuItemDbContext)
        {
            this.dbContext = dbContext;
            this.menuItemDbContext = menuItemDbContext;
        }

        [BindProperty]
        public CartItem cheddar { get; set; }
        public int Quantity { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var menuItemData = menuItemDbContext.MenuItems
                .FirstOrDefault(item => item.Name == "Cheddar Late Than Never");
            if (menuItemData != null)
            {
                var existingCartItem = dbContext.CartItems.FirstOrDefault(item => item.Names == menuItemData.Name);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity++;
                }
                else
                {

                    var cartItem = new CartItem
                    {
                        Names = menuItemData.Name,
                        Prices = menuItemData.Price,
                        Pic = menuItemData.Pics,
                        Quantity = 1,

                    };
                    dbContext.CartItems.Add(cartItem);
                }
                dbContext.SaveChanges();

                ViewData["Message"] = "added";

                return RedirectToPage("/Checkout/Checkout");
            }
            ViewData["Message"] = "whomp whomp";
            return RedirectToPage("/Checkout/Checkout");
        }
    }
}
