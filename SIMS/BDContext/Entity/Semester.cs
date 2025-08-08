using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SIMS.BDContext.Entity
{
    public class Semester
    {
        [Key]
        public int SemesterID { get; set; }

        [Column(TypeName = "nvarchar(100)"), Required]
        public string? Name { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Description { get; set; }

        [AllowNull]
        public DateTime? StartDate { get; set; }

        [AllowNull]
        public DateTime? EndDate { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("Type")]
        public int TypeID { get; set; }
        public Type1? Type { get; set; }
    }

}
