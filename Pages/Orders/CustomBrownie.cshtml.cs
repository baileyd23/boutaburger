using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace boutaburger.Pages.Orders
{
    public class CustomBrownieModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel Brownie { get; set; }
        public double BeefPrice { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            BeefPrice = Brownie.BasePrice;

            return RedirectToPage("/Checkout/Checkout", new { BeefPrice });
        }
    }
}
