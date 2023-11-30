using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomCookieModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel beefburger { get; set; }
        public double Cookie { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Cookie = beefburger.Cookie;

            return RedirectToPage("/Checkout/Checkout", new { Cookie });
        }
    }
}
