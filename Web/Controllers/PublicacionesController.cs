using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PublicacionesController : Controller
    {
        private Sistema miSistema = Sistema.Instancia; 

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
