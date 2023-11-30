using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomBrownieModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel beefburger { get; set; }
        public double Brownie { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Brownie = beefburger.Brownie;

            return RedirectToPage("/Checkout/Checkout", new { Brownie });
        }
    }
}
