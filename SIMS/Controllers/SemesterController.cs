using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Service;

namespace SIMS.Controllers
{
    public class SemesterController : Controller
    {
        private readonly Service_Semester _serviceSemester;
        private readonly SIMSDBContext sIMSDBContext;
        public SemesterController(Service_Semester serviceSemester, SIMSDBContext sIMSDBContext)
        {
            _serviceSemester = serviceSemester;
            this.sIMSDBContext = sIMSDBContext;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Types = await sIMSDBContext.TypesDb.ToListAsync();
            var Semester = await _serviceSemester.GetAllSemestersAsync();
            return View(Semester);
        }
        public async Task<IActionResult> Create(Semester model )
        {

            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                model.UpdatedAt = DateTime.Now;

                sIMSDBContext.SemestersDb.Add(model);
                await sIMSDBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Types = await sIMSDBContext.TypesDb.ToListAsync();
            var classList = await sIMSDBContext.ClassesDb.Include(c => c.Type).ToListAsync();
            return View("Index", classList);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Semester model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _serviceSemester.UpdateSemesterAsync(model);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Semester model)
        {
            await _serviceSemester.DeleteSemesterAsync(model.SemesterID);
            return RedirectToAction("Index");
        }
    }
}
