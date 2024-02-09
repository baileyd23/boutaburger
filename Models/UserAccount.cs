using System.ComponentModel.DataAnnotations;

namespace boutaburger.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Access { get; set; }
    }
}
