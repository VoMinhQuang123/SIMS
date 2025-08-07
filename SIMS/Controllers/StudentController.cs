using Microsoft.AspNetCore.Mvc;
using SIMS.Models;
using SIMS.Service;

namespace SIMS.Controllers
{
    public class StudentController : Controller
    {
<<<<<<< HEAD
        private readonly Service_Student service_Student;
        public StudentController(Service_Student service_Student)
        {
            this.service_Student = service_Student;
        }
        public async Task<IActionResult> Index()
        {
            var Student = await service_Student.GetAllStudentsAsync();
            return View(Student);
        }
        public IActionResult Create()
        {
            return View();
        }

=======
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetStudentsAsync();

            var viewModel = students.Select(s => new StudentViewModel
            {
                StudentID = s.StudentID,
                Name = s.Name,
                Email = s.Email,
                Address = s.Address,
                DoB = s.DoB,
                ClassName = s.Class?.ClassName,
                TypeName = s.Type?.TypeName,
                Username = s.User?.Username
            }).ToList();

            return View(viewModel);



        }
>>>>>>> 4c0943863e934bbf26bf3daa3a457841164258ea
    }
}
