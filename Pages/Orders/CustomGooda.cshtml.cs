using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomBurgerModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel goodaburger { get; set; }
        public double BasePrice { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            BasePrice = goodaburger.BasePrice;

            if (goodaburger.Cheese) BasePrice += .50;

            return RedirectToPage("/Checkout/Checkout", new { BasePrice });
        }
    }
}
