using Microsoft.AspNetCore.Mvc;

namespace UFRSET.Controllers
{
    public class DepartementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
