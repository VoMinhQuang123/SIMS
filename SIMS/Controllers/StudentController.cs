using Microsoft.AspNetCore.Mvc;
using SIMS.Models;
using SIMS.Service;

namespace SIMS.Controllers
{
    public class StudentController : Controller
    {
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

    }
}
