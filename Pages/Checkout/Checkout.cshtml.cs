using boutaburger.Data;
using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace boutaburger.Pages.Checkout
{
    public class CheckoutModel : PageModel
    {
        private readonly CartItemDbContext dbContext;

        public CheckoutModel(CartItemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        
        public decimal Total { get; set; }
        public int Number {  get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public void OnGet()
        {
            CartItems = dbContext.CartItems.ToList();
            CalculateTotal();
        }

        public IActionResult OnPostDelete(int id)
        {
           
            var itemToDelete = CartItems.FirstOrDefault(item => item.Id == id);
            if (itemToDelete != null)
            {
                if (itemToDelete.Quantity > 1)
                {
                    itemToDelete.Quantity--;
                }
                else
                {
                    CartItems.Remove(itemToDelete);
                }
            }
                var dbItemToDelete = dbContext.CartItems.Find(id);
                if (dbItemToDelete != null)
                {
                if (dbItemToDelete.Quantity > 1)
                {
                    dbItemToDelete.Quantity--;
                }
                else
                {
                    dbContext.CartItems.Remove(dbItemToDelete);
                }
                    dbContext.SaveChanges();
                }
                return RedirectToPage("/Checkout/Checkout");
        
        }


        public IActionResult OnPostAdd(int id)
        {

            var itemToAdd = CartItems.FirstOrDefault(item => item.Id == id);
            if (itemToAdd != null)
            {
               
                    itemToAdd.Quantity++;
                
               
            }
            var dbItemToDelete = dbContext.CartItems.Find(id);
            if (dbItemToDelete != null)
            {
               
                    dbItemToDelete.Quantity++;
                     
                dbContext.SaveChanges();
            }
            return RedirectToPage("/Checkout/Checkout");

        }


        private void CalculateTotal()
        {
            Total = CartItems.Sum(item => item.Quantity * (decimal)item.Prices);
        }
        
    }
}