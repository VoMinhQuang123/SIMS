using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMS.BDContext.Entity
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string? Username { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [Required]
        public string? PasswordHash { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public string? Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public Admin? Admin { get; set; }
        public Teacher? Teacher { get; set; }
        public Student? Student { get; set; }
    }
}
