using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomBurgerModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel goodaburger { get; set; }
        public double BeefPrice { get; set; }
        
        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            BeefPrice = 8.42;

            if (goodaburger.Cheese) BeefPrice += .50;

            return RedirectToPage("/Checkout/Checkout", new { BeefPrice });
        }
        
    }
}
