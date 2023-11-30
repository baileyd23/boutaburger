using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomSticksModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel beefburger { get; set; }
        public double Sticks { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Sticks = beefburger.Sticks;

            return RedirectToPage("/Checkout/Checkout", new { Sticks });
        }
    }
}
