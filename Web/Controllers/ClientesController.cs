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

        [HttpGet]
        public IActionResult CargarSaldoBilletera()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult CargarSaldoBilletera(decimal nuevoSaldo)
        {
            try
            {
                if(nuevoSaldo < 0) throw new Exception("El monto no puede ser cero");
                int? idCliente = HttpContext.Session.GetInt32("id");
                string? nombreCliente = HttpContext.Session.GetString("nombre");
                miSistema.CargarSaldoEnBilletera(idCliente.GetValueOrDefault(), nuevoSaldo);
                ViewBag.Exito = $"Se cambio el saldo de la billetera de {nombreCliente} y su saldo es de {nuevoSaldo}";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message; 
            }
            return View();
        }
    }
}
