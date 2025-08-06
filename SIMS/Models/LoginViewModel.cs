using System.ComponentModel.DataAnnotations;

namespace SIMS.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter username, please!")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Enter password, please!")]
        public string? Password { get; set; }
    }
}
