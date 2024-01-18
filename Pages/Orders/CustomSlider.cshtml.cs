using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomSliderModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel sliderburger { get; set; }
        public double BeefPrice { get; set; }
        public void OnGet()
        {
           
        }
        public IActionResult OnPost()
        {
            BeefPrice = 4.32;

            if (sliderburger.Ham) BeefPrice += 3;
            if (sliderburger.Cheese) BeefPrice += .50;
            if (sliderburger.Pineapple) BeefPrice += 1;
            if (sliderburger.Pico) BeefPrice += .50;
            if (sliderburger.Guacamole) BeefPrice += 2;
            if (sliderburger.BBQsauce) BeefPrice += .50;

            return RedirectToPage("/Checkout/Checkout", new { BeefPrice });
        }
    }
}
