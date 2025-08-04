using System.ComponentModel.DataAnnotations;

namespace SIMS.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int TypeID { get; set; }
        public string TypeName { get; set; } // optional

        public int? ClassID { get; set; }
        public string ClassName { get; set; } // optional
    }
}
