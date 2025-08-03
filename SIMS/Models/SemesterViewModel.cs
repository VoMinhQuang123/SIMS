namespace SIMS.Models
{
    public class SemesterViewModel
    {
        public int SemesterID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int TypeID { get; set; }
        public string TypeName { get; set; } // optional
    }
}
