using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomBrookieModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel beefburger { get; set; }
        public double Brookie { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Brookie = beefburger.Brookie;

            return RedirectToPage("/Checkout/Checkout", new { Brookie });
        }
    }
}
