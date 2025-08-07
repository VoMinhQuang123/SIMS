using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Models;
using SIMS.Service;

namespace SIMS.Controllers
{
    public class StudentController : Controller
    {
        private readonly Service_Student service_Student;
        private readonly SIMSDBContext sIMSDBContext;
        public StudentController(Service_Student service_Student, SIMSDBContext sIMSDBContext)
        {
            this.service_Student = service_Student;
            this.sIMSDBContext = sIMSDBContext;
        }
        public async Task<IActionResult> Index()
        {
            var Student = await service_Student.GetAllStudentsAsync();
            ViewBag.Types = await sIMSDBContext.TypesDb.ToListAsync();
            ViewBag.Classes = await sIMSDBContext.ClassesDb.ToListAsync();
            return View(Student);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                model.UpdatedAt = DateTime.Now;
                model.UserID    = 1;

                sIMSDBContext.StudentsDb.Add(model);
                await sIMSDBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Types = await sIMSDBContext.TypesDb.ToListAsync();
            ViewBag.Classes = await sIMSDBContext.ClassesDb.ToListAsync();
            var classList = await sIMSDBContext.StudentsDb.Include(c => c.Type).ToListAsync();
            return View("Index", classList);
        }

    }
}
