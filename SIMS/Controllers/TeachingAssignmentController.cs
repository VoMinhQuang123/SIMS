using Microsoft.AspNetCore.Mvc;
using SIMS.Service;

namespace SIMS.Controllers
{
    public class TeachingAssignmentController : Controller
    {
        private readonly Service_TeachingAssignment service_TeachingAssignment ;
        public TeachingAssignmentController(Service_TeachingAssignment service_TeachingAssignment)
        {
            this.service_TeachingAssignment = service_TeachingAssignment;
        }
        public async Task<IActionResult> IndexAsync()
        {

            var Assignment = await service_TeachingAssignment.GetAllAssignmentsAsync();
            return View(Assignment);
        }
    }
}
