using System.ComponentModel.DataAnnotations;

namespace SIMS.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter Email, please")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Password , please")]// user bat buoc phai nhap du lieu 
        public string Password { get; set; }
    }
}
