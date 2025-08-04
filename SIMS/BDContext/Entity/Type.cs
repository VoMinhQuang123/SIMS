using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SIMS.BDContext.Entity
{
    public class Type
    {
        [Key]
        public int TypeID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? TypeName { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Description { get; set; }

        [AllowNull]
        public DateTime? CreatedAt { get; set; }

        [AllowNull]
        public DateTime? UpdatedAt { get; set; }
    }

}
