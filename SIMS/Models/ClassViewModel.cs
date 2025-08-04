namespace SIMS.Models
{
    public class ClassViewModel
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int TypeID { get; set; }
        public string TypeName { get; set; } // optional, if joined
    }
}
