using System.ComponentModel.DataAnnotations;

namespace SIMS.Models
{
    public class TeachingAssignmentViewModel
    {
        public int AssignmentID { get; set; }

        [Required(ErrorMessage = "Class is required.")]
        [Display(Name = "Class ID")]
        public int ClassID { get; set; }

        [Display(Name = "Class Name")]
        public string? ClassName { get; set; }

        [Required(ErrorMessage = "Course is required.")]
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        [Display(Name = "Course Name")]
        public string? CourseName { get; set; }

        [Required(ErrorMessage = "Teacher is required.")]
        [Display(Name = "Teacher ID")]
        public int TeacherID { get; set; }

        [Display(Name = "Teacher Name")]
        public string? TeacherName { get; set; }

        [Required(ErrorMessage = "Semester is required.")]
        [Display(Name = "Semester ID")]
        public int SemesterID { get; set; }

        [Display(Name = "Semester Name")]
        public string? SemesterName { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Updated At")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
