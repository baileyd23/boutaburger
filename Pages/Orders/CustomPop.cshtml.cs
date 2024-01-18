using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace boutaburger.Pages.Orders
{
    public class CustomPopModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel Pop { get; set; }
        public double BeefPrice { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            BeefPrice = Pop.BasePrice;

            return RedirectToPage("/Checkout/Checkout", new { BeefPrice });
        }
    }
}
