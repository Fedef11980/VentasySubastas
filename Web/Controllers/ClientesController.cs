using AspNetCoreGeneratedDocument;
using Dominio;
using Microsoft.AspNetCore.Components.Forms;
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

        public IActionResult CargarCliente(int id)
        {
            ViewBag.cargarCliente = miSistema.ObtenerUsuarioPorId(id);
            return View();
        }

        public IActionResult CargarSaldoBilletera()
        {            
            return View();
        }
    }
}
