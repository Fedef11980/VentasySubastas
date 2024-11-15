using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PublicacionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
