using boutaburger.Data;
using boutaburger.Models;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace boutaburger.Pages.Orders
{
    [Authorize]
    public class CustomBeefModel : PageModel
    {
        private readonly CartItemDbContext dbContext;
        private readonly MenuItemDbContext menuItemDbContext;

        public CustomBeefModel(CartItemDbContext dbContext, MenuItemDbContext menuItemDbContext)
        {
            this.dbContext = dbContext;
            this.menuItemDbContext = menuItemDbContext;
        }

        [BindProperty]
        public CartItem beefburger { get; set; }
        public int Quantity { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var menuItemData = menuItemDbContext.MenuItems
                .FirstOrDefault(item => item.Name == "BeefCake Burger");

            if (menuItemData != null)
            {
                var existingCartItem = dbContext.CartItems.FirstOrDefault(item => item.Names == menuItemData.Name);
                if (existingCartItem != null)
                {
                    // If the item is already in the cart, increment the quantity
                    existingCartItem.Quantity++;
                }
                else
                {

                    var cartItem = new CartItem
                    {
                        Names = menuItemData.Name,
                        Prices = menuItemData.Price,
                        Pic = menuItemData.Pics,
                        Quantity = beefburger.Quantity,

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