using Microsoft.AspNetCore.Mvc;
using SIMS.Models;

namespace SIMS.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //return View();
            //var students = _context.Students.ToList(); // hoặc từ danh sách cứng để test
            var students = new List<StudentViewModel>
{
                new StudentViewModel {Id = 1, Name = "Nguyen Van A", DoB = new DateTime(2003, 12, 30), Email = "a@gmail.com", Address = "HN", TypeName = "IT" },
                new StudentViewModel { Id = 2, Name = "Le Thi B", DoB = new DateTime(2004, 4, 28), Email = "b@gmail.com", Address = "QN", TypeName = "IT" }
};
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                // Lưu student vào DB tại đây nếu có
                // db.Students.Add(student);
                // db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}
