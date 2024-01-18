using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace boutaburger.Pages.Orders
{
    public class CustomShakesModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel Shakes { get; set; }
        public double BeefPrice { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            BeefPrice = Shakes.BasePrice;

            return RedirectToPage("/Checkout/Checkout", new { BeefPrice });
        }
    }
}
