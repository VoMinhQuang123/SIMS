using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Service;

namespace SIMS.Controllers
{
    public class TypeController : Controller
    {
        private readonly Service_Type service_Type ;
        private readonly SIMSDBContext sIMSDBContext;
        public TypeController(Service_Type service_Type, SIMSDBContext sIMSDBContext)
        {
            this.service_Type = service_Type;
            this.sIMSDBContext = sIMSDBContext;
        }
        public async Task<IActionResult> Index()
        {

            var Type1 = await service_Type.GetAllTypesAsync();
            return View(Type1);
        }
        public async Task<IActionResult> Create(Type1 model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                model.UpdatedAt = DateTime.Now;

                sIMSDBContext.TypesDb.Add(model);
                await sIMSDBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Types = await sIMSDBContext.TypesDb.ToListAsync();
            var SemesterList = await sIMSDBContext.SemestersDb.Include(c => c.Type).ToListAsync();
            return View("Index", SemesterList);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Type1 model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service_Type.UpdateTypeAsync(model);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Type1 model)
        {
            await service_Type.DeleteTypeAsync(model.TypeID);
            return RedirectToAction("Index");
        }
    }
}
