using Microsoft.AspNetCore.Mvc;
using SIMS.BDContext.Entity;
using SIMS.Service;

namespace SIMS.Controllers
{
    public class TeacherController : Controller
    {
        private readonly Service_Teacher service_Teacher;
        private readonly Service_Type service_Type;
        public TeacherController(Service_Teacher service_Teacher, Service_Type service_Type)
        {
            this.service_Teacher = service_Teacher;
            this.service_Type = service_Type;
        }
        public async Task<IActionResult> Index()
        {

            var Teacher = await service_Teacher.GetAllTeachersAsync();
            ViewBag.Types = await service_Type.GetAllTypesAsync();
            return View(Teacher);
        }
        public async Task<IActionResult> Create(Teacher model)
        {

            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                model.UpdatedAt = DateTime.Now;

                var user = new User()
                {
                    Username = model.Email,
                    PasswordHash = "123456",
                    Role = "Teacher"
                };
                await service_Teacher.AddTeacherAsync(model, user);

                return RedirectToAction("Index");
            }
            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Teacher model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service_Teacher.UpdateTeacherAsync(model);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Teacher model)
        {
            await service_Teacher.DeleteTeacherAsync(model.TeacherID);
            return RedirectToAction("Index");
        }       
    }
}
