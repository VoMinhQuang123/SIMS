namespace SIMS.Models
{
    public class TeacherViewModel
    {
        public int TeacherID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int TypeID { get; set; }
        public string TypeName { get; set; } // optional
    }
}
