using System.ComponentModel.DataAnnotations;

namespace SIMS.Models
{
    public class CourseViewModel()
    {
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Course name is required.")]
        [Display(Name = "Course Name")]
        [StringLength(100, ErrorMessage = "Course name cannot exceed 100 characters.")]
        public string? NameCourse { get; set; }

        [Display(Name = "Description")]
        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
        public string? DescriptionCourse { get; set; }

        [Display(Name = "Created At")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Type is required.")]
        [Display(Name = "Type ID")]
        public int TypeID { get; set; }

        [Display(Name = "Type Name")]
        public string? TypeName { get; set; }
    }
}
