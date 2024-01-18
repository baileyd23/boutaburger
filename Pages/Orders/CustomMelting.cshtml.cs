using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomMeltingModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel meltingburger { get; set; }
        public double BeefPrice { get; set; }
        public void OnGet()
        {
           
        }
        public IActionResult OnPost()
        {
            BeefPrice = 12.52; 

            if (meltingburger.Bacon) BeefPrice += 3;
            if (meltingburger.Cheese) BeefPrice += .50;

            return RedirectToPage("/Checkout/Checkout", new { BeefPrice });
        }
    }
}
