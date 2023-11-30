using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomPopModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel beefburger { get; set; }
        public double Pop { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Pop = beefburger.Pop;

            return RedirectToPage("/Checkout/Checkout", new { Pop });
        }
    }
}
