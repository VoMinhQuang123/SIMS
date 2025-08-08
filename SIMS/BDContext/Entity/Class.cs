using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMS.BDContext.Entity
{
    public class Class
    {
        [Key]
        public int ClassID { get; set; }

        [Column(TypeName = "nvarchar(100)"), Required]
        public string? ClassName { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("Type")]
        public int TypeID { get; set; }
        public Type1? Type { get; set; }
    }

}
