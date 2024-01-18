using boutaburger.Data;
using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages
{
    public class SecretOrderModel : PageModel
    {
        public List<BurgerOrder> BurgerOrders = new List<BurgerOrder>();
        private readonly ApplicationDbContext _context;
        public SecretOrderModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            BurgerOrders = _context.BurgerOrders.ToList();
        }
    }
}
