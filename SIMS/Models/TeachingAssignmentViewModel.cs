namespace SIMS.Models
{
    public class TeachingAssignmentViewModel
    {
        public int AssignmentID { get; set; }

        public int ClassID { get; set; }
        public string ClassName { get; set; }

        public int CourseID { get; set; }
        public string CourseName { get; set; }

        public int TeacherID { get; set; }
        public string TeacherName { get; set; }

        public int SemesterID { get; set; }
        public string SemesterName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
