using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace boutaburger.Pages.Orders
{
    public class CustomTeaModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel Tea { get; set; }
        public double BeefPrice { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            BeefPrice = Tea.BasePrice;

            return RedirectToPage("/Checkout/Checkout", new { BeefPrice });
        }
    }
}
