using boutaburger.Data;
using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class CheckoutModel : PageModel
    {
        public string BurgerName { get; set; }
        public float BeefPrice { get; set; }
        public string ImageTitle { get; set; }

        private readonly ApplicationDbContext _context;
        public CheckoutModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

            BurgerOrder burgerOrder = new BurgerOrder();
            burgerOrder.BurgerName = BurgerName;
            burgerOrder.BasePrice = BeefPrice;

            _context.BurgerOrders.Add(burgerOrder);
            _context.SaveChanges();
        }
    }
}
