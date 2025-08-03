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

        public string Major { get; set; }
    }
}
