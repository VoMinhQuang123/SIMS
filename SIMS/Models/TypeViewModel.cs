using System.ComponentModel.DataAnnotations;

namespace SIMS.Models
{
    public class TypeViewModel
    {
        public int TypeID { get; set; }

        [Required(ErrorMessage = "Type Name is required.")]
        [Display(Name = "Type Name")]
        [StringLength(100, ErrorMessage = "Type Name cannot exceed 100 characters.")]
        public string? TypeName { get; set; }

        [Display(Name = "Description")]
        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
        public string? Description { get; set; }

        [Display(Name = "Created At")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
