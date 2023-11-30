using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomCheddarModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel cheddarburger { get; set; }
        public double BasePrice { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            BasePrice = cheddarburger.BasePrice;

            if (cheddarburger.Cheese) BasePrice += .50;

            return RedirectToPage("/Checkout/Checkout", new { BasePrice });
        }
    }
}
