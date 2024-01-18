using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomSlawModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel slawburger { get; set; }
        public double BeefPrice { get; set; }
        public void OnGet()
        {
           
        }
        public IActionResult OnPost()
        {
            BeefPrice = 6.26;

            if (slawburger.Coleslaw) BeefPrice += .50;

            return RedirectToPage("/Checkout/Checkout", new { BeefPrice });
        }
    }
}
