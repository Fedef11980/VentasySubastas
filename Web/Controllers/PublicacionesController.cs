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

        /*[HttpGet]
        public IActionResult Listado()
        {
            ViewBag.Listado = miSistema.Publicaciones;
            if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
            return View();
        }*/

        [HttpGet]
        public IActionResult BuscarPorPublicacion(string publicacion)
        {
            try
            {
                if (string.IsNullOrEmpty(publicacion)) throw new Exception ("Debe ingresar un tipo de publicacion correcta o que no esté vacía");
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
        public IActionResult OfertaEnSubasta(int id, decimal monto)
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

        [HttpPost]
        public IActionResult FinalizarPublicacion(int id)
        {
            try
            {
                // Obtener la publicación
                Publicacion publicacionBuscada = Sistema.Instancia.ObtenerPublicacionPorId(id);
                if (publicacionBuscada == null) throw new Exception("La publicación no existe.");
                if (publicacionBuscada.Estado != Estado.ABIERTA) throw new Exception("La publicación no está en un estado válido para finalizar.");

                // Simula el usuario actual (puedes obtenerlo desde el sistema de autenticación)
                Usuario usuarioActual = Sistema.Instancia.ObtenerUsuarioPorId(id);

                // Finalizar la publicación (la lógica depende de la clase Venta o Subasta)
                publicacionBuscada.FinalizarPublicacion(publicacionBuscada, usuarioActual, DateTime.Now);

                // Mensaje de éxito
                TempData["Mensaje"] = $"La publicación '{publicacionBuscada.Nombre}' fue finalizada exitosamente.";
            }
            catch (Exception ex)
            {
                // Mensaje de error
                TempData["Mensaje"] = $"Error: {ex.Message}";
            }

            return RedirectToAction("Listado"); // Redirigir a la lista de publicaciones
        }

    }
}
