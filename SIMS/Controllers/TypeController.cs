using Microsoft.AspNetCore.Mvc;
using SIMS.Service;

namespace SIMS.Controllers
{
    public class TypeController : Controller
    {
        private readonly Service_Type service_Type ;
        public TypeController(Service_Type service_Type)
        {
            this.service_Type = service_Type;
        }
        public async Task<IActionResult> IndexAsync()
        {

            var Type = await service_Type.GetAllTypesAsync();
            return View(Type);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
