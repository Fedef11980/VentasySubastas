using Dominio;
using Microsoft.AspNetCore.Mvc;


namespace Dominio.Controllers
{
    public class PublicacionesController : Controller
    {
        Sistema miSistema = Sistema.Instancia;
        
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Listado()
        {
            if (HttpContext.Session.GetString("rol") == null)
            {
                return View("NoAutorizado");
            }
            ViewBag.Listado = miSistema.Publicaciones;
            if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
            return View();
        }

        [HttpGet]
        public IActionResult ListadoSubastas()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Admin")
            {
                return View("NoAutorizado");
            }

            ViewBag.Subastas = miSistema.ListadoSubastas();

            if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
            return View();
        }

        public IActionResult DetallePublicacion(int id)
        {
            if (HttpContext.Session.GetString("rol") == null)
            {
                return View("NoAutorizado");
            }
            ViewBag.detallePublicacion = miSistema.ObtenerPublicacionPorId(id);
            return View();
        }

        [HttpGet]
        public IActionResult BuscarPorPublicacion(string publicacion)
        {
            try
            {
                if (string.IsNullOrEmpty(publicacion)) throw new Exception("Debe ingresar un tipo de publicacion correcta o que no esté vacía");
                ViewBag.Listado = miSistema.ObtenerPublicacionPorTipo(publicacion);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View("Listado");
        }

        [HttpPost]
        public IActionResult FinalizarPublicacion(int id)
        {
            if (HttpContext.Session.GetString("rol") == null)
            {
                return View("NoAutorizado");
            }
            try
            {
                // Obtener la publicación
                Publicacion publicacion = Sistema.Instancia.ObtenerPublicacionPorId(id);
                if (publicacion == null) throw new Exception("La publicación no existe.");
                if (publicacion.Estado != Estado.ABIERTA) throw new Exception("La publicación no está en un estado válido para finalizar.");
                
                // Simula el usuario actual (puedes obtenerlo desde el sistema de autenticación)
                Usuario usuarioActual = Sistema.Instancia.ObtenerUsuarioPorId(id);

                // Finalizar la publicación (la lógica depende de la clase Venta o Subasta)
                publicacion.FinalizarPublicacion(publicacion, usuarioActual, DateTime.Now);

                // Mensaje de éxito
                TempData["Mensaje"] = $"La publicación '{publicacion.Nombre}' fue comprada exitosamente.";
            }
            catch (Exception ex)
            {
                // Mensaje de error
                TempData["Mensaje"] = $"Error: {ex.Message}";
            }
            return RedirectToAction("Listado"); // Redirigir a la lista de publicaciones
        }

        [HttpPost]
        public IActionResult CerrarSubasta(int id)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Admin")
            {
                return View("NoAutorizado");
            }
            try
            {
                // Verificar que el usuario actual es un administrador
                int? idUsuario = HttpContext.Session.GetInt32("id");
                Usuario usuarioActual = miSistema.ObtenerUsuarioPorId(idUsuario.GetValueOrDefault());

                if (usuarioActual == null || !(usuarioActual is Administrador))
                {
                    throw new Exception("Solo un administrador puede cerrar una subasta.");
                }

                // Obtener la publicación (subasta)
                Publicacion publicacion = miSistema.ObtenerPublicacionPorId(id);

                if (publicacion == null) throw new Exception("La publicación no existe.");
                
                if (publicacion.Estado != Estado.ABIERTA) throw new Exception("La subasta no está en un estado válido para ser cerrada.");
                
                // Finalizar la subasta
                publicacion.FinalizarPublicacion(publicacion, usuarioActual, DateTime.Now);

                TempData["Exito"] = "La subasta se cerró exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al cerrar la subasta: {ex.Message}";
            }
            return RedirectToAction("ListadoSubastas");
        }

        public IActionResult AltaPublicacionVenta(int id)
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") != "Admin")
            {
                return View("NoAutorizado");
            }
            ViewBag.altaPublicacionVenta = miSistema.ObtenerPublicacionPorId(id);
            return View();
        }

        [HttpPost]
        public IActionResult OfertaEnSubasta(int id, decimal monto)
        {
            if (HttpContext.Session.GetString("rol") == null)
            {
                return View("NoAutorizado");
            }
            try
            {   
                int? idCliente = HttpContext.Session.GetInt32("id");

                if (monto < 0) throw new Exception("El monto no puede ser menor que cero");
                miSistema.AgregarOfertaAUnaSubasta(idCliente.GetValueOrDefault(), id, monto, DateTime.Now);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return RedirectToAction("Listado");
        }

        //Metodos para ver subastas con administrador
        public IActionResult ListarSubastas()
        {
            if (HttpContext.Session.GetString("rol") == null)
            {
                return View("NoAutorizado");
            }
            return View();
        }
    }
}
