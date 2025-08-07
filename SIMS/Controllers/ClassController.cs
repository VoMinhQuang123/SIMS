using Microsoft.AspNetCore.Mvc;
using SIMS.Service;
using System.Threading.Tasks;

namespace SIMS.Controllers
{
    public class ClassController : Controller
    {
        private readonly Service_Class service_Class;

        public ClassController(Service_Class service_Class)
        {
            this.service_Class = service_Class;
        }
        public async Task<IActionResult> Index()
        {
            var Class = await service_Class.GetAllClassesAsync();
            return View(Class);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
