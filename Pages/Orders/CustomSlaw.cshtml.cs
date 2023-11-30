using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomSlawModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel slawburger { get; set; }
        public double BasePrice { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            BasePrice = slawburger.BasePrice;

            if (slawburger.Coleslaw) BasePrice += .50;

            return RedirectToPage("/Checkout/Checkout", new { BasePrice });
        }
    }
}
