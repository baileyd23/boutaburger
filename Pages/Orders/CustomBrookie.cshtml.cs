using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomBrookieModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel Brookie { get; set; }
        public double BeefPrice { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            BeefPrice = Brookie.BasePrice;
            

            return RedirectToPage("/Checkout/Checkout", new { BeefPrice });
        }
    }
}
