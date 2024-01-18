using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomSoulModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel soulburger { get; set; }
        public double BeefPrice { get; set; }
        public void OnGet()
        {
           
        }
        public IActionResult OnPost()
        {
            BeefPrice = 8.74;

            if (soulburger.OnionRings) BeefPrice += 3;
            if (soulburger.Cheese) BeefPrice += .50;
            if (soulburger.Habanero) BeefPrice += 3;
            if (soulburger.GhostPepper) BeefPrice += .50;

            return RedirectToPage("/Checkout/Checkout", new { BeefPrice });
        }
    }
}
