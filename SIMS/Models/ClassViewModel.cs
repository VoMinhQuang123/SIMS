using System.ComponentModel.DataAnnotations;

namespace SIMS.Models
{
   public class ClassViewModel()
    {
        public int ClassID { get; set; }

        [Required(ErrorMessage = "Class name is required.")]
        [Display(Name = "Class Name")]
        [StringLength(100, ErrorMessage = "Class name cannot exceed 100 characters.")]
        public string ClassName { get; set; }

        [Display(Name = "Description")]
        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
        public string? Description { get; set; }

        [Display(Name = "Created At")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Type is required.")]
        [Display(Name = "Type ID")]
        public int TypeID { get; set; }

        // Optional: show the name of the type in display views
        public string? TypeName { get; set; }
    }
}
