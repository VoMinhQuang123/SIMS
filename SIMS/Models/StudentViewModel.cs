using System.ComponentModel.DataAnnotations;

namespace SIMS.Models
{
    public class StudentViewModel
    {
        public int StudentID { get; set; }

<<<<<<< HEAD
        [Required(ErrorMessage = "Student name is required.")]
        [Display(Name = "Full Name")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DoB { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(100)]
        public string? Email { get; set; }

        [Display(Name = "Address")]
        [StringLength(200)]
        public string? Address { get; set; }

        [Display(Name = "Created At")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Type is required.")]
        [Display(Name = "Type ID")]
        public int TypeID { get; set; }

        [Display(Name = "Type Name")]
        public string? TypeName { get; set; }

        [Display(Name = "Class ID")]
        public int? ClassID { get; set; }

        [Display(Name = "Class Name")]
        public string? ClassName { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        [Display(Name = "User ID")]
        public int UserID { get; set; }
=======
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
>>>>>>> 4c0943863e934bbf26bf3daa3a457841164258ea
    }
}
