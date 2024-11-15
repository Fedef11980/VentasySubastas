using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PublicacionesController : Controller
    {
        Sistema miSistema = new Sistema();  

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult VistaVentas()
        {
            ViewBag.ListadoArticulosVenta = miSistema.Articulos;
            return View();
        }

        public IActionResult VistaSubastas()
        {
            return View();
        }
    }
}
