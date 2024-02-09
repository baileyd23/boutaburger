using System.ComponentModel.DataAnnotations;
namespace boutaburger.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public string Names { get; set; }
        public double Prices { get; set; }
        public string Pic { get; set; }
        public int Quantity { get; set; }
    }
}
