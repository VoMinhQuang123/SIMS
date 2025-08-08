using Microsoft.AspNetCore.Mvc;
using SIMS.BDContext.Entity;
using SIMS.Service;

namespace SIMS.Controllers
{
    public class TeachingAssignmentController : Controller
    {
        private readonly Service_TeachingAssignment service_TeachingAssignment ;
        private readonly Service_Class service_Class;
        private readonly Service_Teacher service_Teacher;
        private readonly Service_Course service_Course;
        private readonly Service_Semester service_Semester;
        public TeachingAssignmentController(Service_TeachingAssignment service_TeachingAssignment, Service_Class service_Class, Service_Teacher service_Teacher, Service_Course service_Course, Service_Semester service_Semester)
        {
            this.service_TeachingAssignment = service_TeachingAssignment;
            this.service_Class = service_Class;
            this.service_Teacher = service_Teacher;
            this.service_Course = service_Course;
            this.service_Semester = service_Semester;
        }
        public async Task<IActionResult> Index()
        {

            var Assignment = await service_TeachingAssignment.GetAllAssignmentsAsync() ?? new List<TeachingAssignment>();
            ViewBag.Semester = await service_Semester.GetAllSemestersAsync() ?? new List<Semester>(); ;
            ViewBag.Classes = await service_Class.GetAllClassesAsync() ?? new List<Class>();
            ViewBag.Teacher = await service_Teacher.GetAllTeachersAsync() ?? new List<Teacher>();
            ViewBag.Course = await service_Course.GetAllCoursesAsync() ?? new List<Course>();

            ViewBag.NextID = Assignment.Count + 1;
            return View(Assignment);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeachingAssignment model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                model.UpdatedAt = DateTime.Now;
                await service_TeachingAssignment.AddTeachingAssignmentAsync(model);
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TeachingAssignment model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service_TeachingAssignment.UpdateTeachingAssignmentAsync(model);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(TeachingAssignment model)
        {
            await service_TeachingAssignment.DeleteTeachingAssignmentAsync(model.AssignmentID);
            return RedirectToAction("Index");
        }
    }
}
