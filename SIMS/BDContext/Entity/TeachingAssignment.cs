using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMS.BDContext.Entity
{
    public class TeachingAssignment
    {
        [Key]
        public int AssignmentID { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("Class")]
        public int ClassID { get; set; }
        public Class? Class { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public Course? Course { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherID { get; set; }
        public Teacher? Teacher { get; set; }

        [ForeignKey("Semester")]
        public int SemesterID { get; set; }
        public Semester? Semester { get; set; }
    }

}
