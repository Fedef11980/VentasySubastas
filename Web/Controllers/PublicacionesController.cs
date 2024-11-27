using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PublicacionesController : Controller
    {
        private Sistema miSistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult ListarPublicaciones()
        {
            ViewBag.ListadoPublicaciones = miSistema.Publicaciones;
            return View();
        }

        [HttpGet]
        public IActionResult BuscarPorPublicacion(string publicacion)
        {
            try
            {
                if (string.IsNullOrEmpty(publicacion)) throw new Exception ("Debe ingresar un tipo de publicacion");
                ViewBag.ListadoPublicaciones = miSistema.ObtenerPublicacionPorTipo(publicacion); 
            }
            catch (Exception ex)  
            {
                ViewBag.Error = ex.Message;
            }
            return View("ListarPublicaciones");
        }

        public IActionResult DetallePublicacion(int id)
        {
            ViewBag.detallePublicacion = miSistema.ObtenerPublicacionPorId(id);
            return View();  
        }

        //Pantalla para ver venta hecha con exito
        /*public IActionResult AltaPublicacionVenta(int id) 
        {
            ViewBag.altaPublicacionVenta = miSistema.ObternerVentaPorId(id);   
            return View();  
        }*/

        [HttpPost]
        public IActionResult OfertaEnSubasta(int id, double monto)
        {
            try
            {
                if (monto < 0) throw new Exception("El monto no puede ser menor que cero");                
                int? idCliente = HttpContext.Session.GetInt32("id");
                miSistema.AgregarOfertaAUnaSubasta(idCliente.GetValueOrDefault(), id, monto, DateTime.Now);
            }
            catch (Exception ex)
            { 

                ViewBag.Error = ex.Message; 
            }
            return RedirectToAction("ListarPublicaciones");
        }

        //Metodos para ver subastas con administrador
        public IActionResult ListarSubastas()
        {
            return View();
        }

    }
}
