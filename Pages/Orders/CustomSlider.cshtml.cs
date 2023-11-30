using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Orders
{
    public class CustomSliderModel : PageModel
    {
        [BindProperty]
        public ThisIsAModel sliderburger { get; set; }
        public double BasePrice { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            BasePrice = sliderburger.BasePrice;

            if (sliderburger.Ham) BasePrice += 3;
            if (sliderburger.Cheese) BasePrice += .50;
            if (sliderburger.Pineapple) BasePrice += 1;
            if (sliderburger.Pico) BasePrice += .50;
            if (sliderburger.Guacamole) BasePrice += 2;
            if (sliderburger.BBQsauce) BasePrice += .50;

            return RedirectToPage("/Checkout/Checkout", new { BasePrice });
        }
    }
}
