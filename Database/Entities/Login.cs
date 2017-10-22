using System.ComponentModel.DataAnnotations;

namespace project.Entities{
    public class Login{
        [Required]
        [EmailAddress]
        public string username{set;get;}
        [Required]
        [MaxLength(50)]
        public string password{set;get;}
    }
}