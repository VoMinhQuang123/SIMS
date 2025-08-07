using System.ComponentModel.DataAnnotations;

namespace SIMS.Models
{
    public class StudentViewModel
    {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Student name is required.")]
        [Display(Name = "Full Name")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DoB { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(100)]
        public string? Email { get; set; }

        [Display(Name = "Address")]
        [StringLength(200)]
        public string? Address { get; set; }

        [Display(Name = "Created At")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Type is required.")]
        [Display(Name = "Type ID")]
        public int TypeID { get; set; }

        [Display(Name = "Type Name")]
        public string? TypeName { get; set; }

        [Display(Name = "Class ID")]
        public int? ClassID { get; set; }

        [Display(Name = "Class Name")]
        public string? ClassName { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        [Display(Name = "User ID")]
        public int UserID { get; set; }
    }
}
