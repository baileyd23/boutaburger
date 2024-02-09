using System.ComponentModel.DataAnnotations;

namespace boutaburger.Models
{
    public class SearchDb
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Headline { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
