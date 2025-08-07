using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Service;
using System.Threading.Tasks;

namespace SIMS.Controllers
{
    public class ClassController : Controller
    {
        private readonly Service_Class service_Class;
        private readonly SIMSDBContext sIMSDBContext;

        public ClassController(Service_Class service_Class, SIMSDBContext sIMSDBContext)
        {
            this.sIMSDBContext = sIMSDBContext;
            this.service_Class = service_Class;
        }
        public async Task<IActionResult> Index()
        {
            var Class = await service_Class.GetAllClassesAsync();
            ViewBag.Types = await sIMSDBContext.TypesDb.ToListAsync();
            return View(Class);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Class model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                model.UpdatedAt = DateTime.Now;

                sIMSDBContext.ClassesDb.Add(model);
                await sIMSDBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Types = await sIMSDBContext.TypesDb.ToListAsync();
            var classList = await sIMSDBContext.ClassesDb.Include(c => c.Type).ToListAsync();
            return View("Index", classList);
        }

    }
}
