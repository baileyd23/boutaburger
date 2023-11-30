using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomBeefModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel beefburger { get; set; }
        public double BasePrice { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            BasePrice = beefburger.BasePrice;

            if (beefburger.Bacon) BasePrice += 3;
            if (beefburger.SauteedGarlic) BasePrice += .50;

            return RedirectToPage("/Checkout/Checkout", new {BasePrice});
        }
    }
}
