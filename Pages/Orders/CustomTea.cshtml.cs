using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomTeaModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel beefburger { get; set; }
        public double Tea { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Tea = beefburger.Tea;

            return RedirectToPage("/Checkout/Checkout", new { Tea });
        }
    }
}
