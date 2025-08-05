using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SIMS.BDContext.Entity
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Role { get; set; }

        [AllowNull]
        public DateTime? CreatedAt { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User? User { get; set; }
    }

}
