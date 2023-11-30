using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomMeltingModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel meltingburger { get; set; }
        public double BasePrice { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            BasePrice = meltingburger.BasePrice;

            if (meltingburger.Bacon) BasePrice += 3;
            if (meltingburger.Cheese) BasePrice += .50;

            return RedirectToPage("/Checkout/Checkout", new { BasePrice });
        }
    }
}
