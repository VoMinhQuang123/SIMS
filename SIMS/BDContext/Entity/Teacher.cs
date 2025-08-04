using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SIMS.BDContext.Entity
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Email { get; set; }

        [AllowNull]
        public DateTime? CreatedAt { get; set; }

        [AllowNull]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("Type")]
        public int TypeID { get; set; }
        public Type? Type { get; set; }
    }

}
