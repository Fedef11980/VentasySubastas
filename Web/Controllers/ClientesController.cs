using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ClientesController : Controller
    {
        Sistema miSistema = Sistema.Instancia;

        public IActionResult ListarClientes()
        {
            ViewBag.Listado = miSistema.ListarClientes();
            return View();
        }

        public IActionResult CargarSaldo()
        {

            return View();
        }
    }
}
