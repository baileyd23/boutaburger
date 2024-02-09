using boutaburger.Models;
using Microsoft.EntityFrameworkCore;

namespace boutaburger.Models.Domain
{
    public class Menu
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
