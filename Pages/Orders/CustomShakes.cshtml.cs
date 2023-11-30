using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomShakesModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel beefburger { get; set; }
        public double Shakes { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Shakes = beefburger.Shakes;

            return RedirectToPage("/Checkout/Checkout", new { Shakes });
        }
    }
}
