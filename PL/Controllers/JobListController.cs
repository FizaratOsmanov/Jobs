using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class JobListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
