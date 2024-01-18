using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace boutaburger.Pages.Orders
{
    public class CustomCookieModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel Cookie { get; set; }
        public double BeefPrice { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            BeefPrice = Cookie.BasePrice;

            return RedirectToPage("/Checkout/Checkout", new { BeefPrice });
        }
    }
}
