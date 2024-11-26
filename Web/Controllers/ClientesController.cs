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
        public IActionResult CambiarSaldoBilletera()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult CambiarSaldoBilletera(int idCliente, decimal nuevoSaldo)
        {
            try
            {
                if(nuevoSaldo < 0) throw new Exception("El monto no puede ser cero");
                if (idCliente == null) throw new Exception("Cliente no encontrado");
                miSistema.CargarSaldoEnBilletera(idCliente, nuevoSaldo);
                ViewBag.Exito = $"Se cambio el saldo de la billetera del cleinte {idCliente}";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message; 
            }
            return View();
        }
    }
}
