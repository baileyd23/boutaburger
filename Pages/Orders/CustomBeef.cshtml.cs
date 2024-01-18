using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomBeefModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel beefburger { get; set; }
        public double BeefPrice { get; set; }
        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            BeefPrice = 5.29;

            if (beefburger.Bacon) BeefPrice += 3;
            if (beefburger.SauteedGarlic) BeefPrice += .50;

            return RedirectToPage("/Checkout/Checkout", new {BeefPrice});
        }
    }
}
