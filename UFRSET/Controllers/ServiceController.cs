using Microsoft.AspNetCore.Mvc;

namespace UFRSET.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
