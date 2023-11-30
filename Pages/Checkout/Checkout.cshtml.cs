using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class CheckoutModel : PageModel
    {
        
        public double BeefPrice { get; set; }
        public string ImageTitle { get; set; }
        public void OnGet(double BeefPrice)
        {
           
        }
    }
}
