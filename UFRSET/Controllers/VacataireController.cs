using Microsoft.AspNetCore.Mvc;

namespace UFRSET.Controllers
{
    public class VacataireController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
