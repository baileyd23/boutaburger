using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomRingsModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel beefburger { get; set; }
        public double Rings { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Rings = beefburger.Rings;

            return RedirectToPage("/Checkout/Checkout", new { Rings });
        }
    }
}
