using boutaburger.Data;
using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace boutaburger.Pages.Checkout
{
    public class CardModel : PageModel
    {
        private readonly CartItemDbContext dbContext;
        private readonly PastOrderDbContext pastOrderDbContext;


        public CardModel(CartItemDbContext dbContext, PastOrderDbContext pastOrderDbContext)
        {
            this.dbContext = dbContext;
            this.pastOrderDbContext = pastOrderDbContext;
        }

        [BindProperty]
        public CartItem card { get; set; }

        public int Date { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (card != null)
            {
                var existingCartItem = dbContext.CartItems.FirstOrDefault(item => item.Names == card.Names);

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity++;
                }
                else
                {
                    var pastOrder = new PastOrder
                    {
                        Namey = card.Names,
                        Pricey = card.Prices,
                        Picy = card.Pic,
                        Quantiy = card.Quantity,
                    };

                    pastOrderDbContext.PastOrders.Add(pastOrder);
                }

                dbContext.SaveChanges();
                pastOrderDbContext.SaveChanges();
            }

            dbContext.CartItems.RemoveRange();
            return RedirectToPage(""); 
        }
    }
}
