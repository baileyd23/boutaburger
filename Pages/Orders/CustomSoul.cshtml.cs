using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomSoulModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel soulburger { get; set; }
        public double BasePrice { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            BasePrice = soulburger.BasePrice;

            if (soulburger.OnionRings) BasePrice += 3;
            if (soulburger.Cheese) BasePrice += .50;
            if (soulburger.Habanero) BasePrice += 3;
            if (soulburger.GhostPepper) BasePrice += .50;

            return RedirectToPage("/Checkout/Checkout", new { BasePrice });
        }
    }
}
