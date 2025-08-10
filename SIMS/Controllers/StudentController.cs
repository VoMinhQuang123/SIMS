using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Interface;
using SIMS.Models;
using SIMS.Service;

namespace SIMS.Controllers
{
    public class StudentController : Controller
    {
        private readonly Service_Student service_Student;
        private readonly Service_Class service_Class;
        private readonly Service_Type service_Type;
        public StudentController(Service_Student service_Student, Service_Class service_Class, Service_Type service_Type)
        {
            this.service_Student = service_Student;
            this.service_Class = service_Class;
            this.service_Type = service_Type;
        }
        public async Task<IActionResult> Index()
        {
            var Student = await service_Student.GetAllStudentsAsync();
            ViewBag.Types = await service_Type.GetAllTypesAsync();
            ViewBag.Classes = await service_Class.GetAllClassesAsync();
            ViewBag.NextID = Student.Count + 1;
            return View(Student);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                model.UpdatedAt = DateTime.Now;

                var user = new User()
                {
                    Username = model.Email,
                    PasswordHash = "123456",
                    Role = "Student"
                };
                await service_Student.AddStudentAsync(model, user);

                return RedirectToAction("Index");
            }
            return View("Index");
        }
        [HttpGet]
        public async Task<JsonResult> GetClassesByType(int typeId)
        {
            var classes = await service_Class.GetClassByIDTypeAsync(typeId);
            return Json(classes);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service_Student.UpdateStudentAsync(model);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Student model)
        {
            await service_Student.DeleteStudentAsync(model.StudentID);
            return RedirectToAction("Index");
        }
    }
}
