using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomCheddarModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel cheddarburger { get; set; }
        public double BeefPrice { get; set; }
        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            BeefPrice = 8.42;

            if (cheddarburger.Cheese) BeefPrice += .50;

            return RedirectToPage("/Checkout/Checkout", new { BeefPrice });
        }
    }
}
