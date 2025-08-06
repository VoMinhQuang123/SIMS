using System.ComponentModel.DataAnnotations;

namespace SIMS.Models
{
    public class StudentViewModel
    {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        public string? Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DoB { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        public string? Address { get; set; }

        public int TypeID { get; set; }
        public string? TypeName { get; set; } // Tên loại: Student, Teacher...

        public int? ClassID { get; set; }
        public string? ClassName { get; set; } // Tên lớp nếu cần hiển thị

        public int UserID { get; set; }
        public string? Username { get; set; } // Tên tài khoản (bảng Users)

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Thêm cho mục đích hiển thị hoặc thao tác UI
        public bool IsSelected { get; set; } // Dùng trong checkbox list, select table...
    }
}
