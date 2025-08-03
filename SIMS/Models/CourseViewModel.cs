namespace SIMS.Models
{
    public class CourseViewModel
    {
        public string NameCourse { get; set; }
        public string DescriptionCourse { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Vote { get; set; }  // Giá trị từ 0–5
        public bool Status { get; set; }
    }
}
