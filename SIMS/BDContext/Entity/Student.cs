using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SIMS.BDContext.Entity
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Name { get; set; }

        public DateTime? DoB { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Email { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Address { get; set; }

        [AllowNull]
        public DateTime? CreatedAt { get; set; }

        [AllowNull]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("Type")]
        public int TypeID { get; set; }
        public Type1? Type { get; set; }

        [ForeignKey("Class")]
        public int? ClassID { get; set; }
        public Class? Class { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User? User { get; set; }
    }

}
