using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomFriesModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel beefburger { get; set; }
        public double Fries { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Fries = beefburger.Fries;

            return RedirectToPage("/Checkout/Checkout", new { Fries });
        }
    }
}
