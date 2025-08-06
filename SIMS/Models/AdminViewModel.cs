using System.ComponentModel.DataAnnotations;

namespace SIMS.Models
{
    public class AdminViewModel()
    {
        public int AdminID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Full Name")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email Address")]
        [StringLength(100)]
        public string? Email { get; set; }

        [Display(Name = "Role")]
        [StringLength(50)]
        public string Role { get; set; } = "Admin";

        [Display(Name = "Created At")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "User ID is required.")]
        [Display(Name = "User ID")]
        public int UserID { get; set; }
    }
}
