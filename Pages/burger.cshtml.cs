using boutaburger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace boutaburger.Pages
{ 
    public class burgerModel : PageModel
    {
       public List<ThisIsAModel> burgerDB = new List<ThisIsAModel>()
       {
           new ThisIsAModel(){ImageTitle="beefCakeBurger",
           BeefName = "BeefCake Burger",
           BasePrice = 5.29,
           Bacon=false,
           SauteedGarlic=false},

            new ThisIsAModel(){ImageTitle="as_gooda_as_it_gets",
           BeefName = "As Gooda as it Gets",
           BasePrice = 8.42,
           Cheese=false},

             new ThisIsAModel(){ImageTitle="iFoughtTheSlawBurger",
           BeefName = "I Fought the Slaw",
           BasePrice = 6.26,
           Coleslaw=false,},

              new ThisIsAModel(){ImageTitle="sellYourSoulBurger",
           BeefName = "Sell Your Soul Burger",
           BasePrice = 8.74,
           OnionRings=false,
           Habanero=false,
           GhostPepper=false,
           Cheese=false},

               new ThisIsAModel(){ImageTitle="cheddarLateThanNever",
           BeefName = "Cheddar Late Than Never",
           BasePrice = 8.42,
           Cheese=false},

                new ThisIsAModel(){ImageTitle="imMelting",
           BeefName = "Im Melting",
           BasePrice = 12.52,
           Bacon=false,
           Cheese=false},

                 new ThisIsAModel(){ImageTitle="slipNslider",
           BeefName = "Slip ~n~ Slider",
           BasePrice = 4.32,
           Ham=false,
           Pineapple=false,
           Pico=false,
           Guacamole=false,
           BBQsauce=false,
           Cheese=false}
       };
        public void OnGet()
        {
        }
    }
}
