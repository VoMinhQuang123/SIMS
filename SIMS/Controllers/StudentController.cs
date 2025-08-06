using Microsoft.AspNetCore.Mvc;
using SIMS.Models;
using SIMS.Service;

namespace SIMS.Controllers
{
    public class StudentController : Controller
    {
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
    }
}
