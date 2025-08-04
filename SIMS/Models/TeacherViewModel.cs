using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace SIMS.Models
{
    public class TeacherViewModel
    {
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string TeacherEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int TypeID { get; set; }
        public string TypeName { get; set; } // optional
    }
}
