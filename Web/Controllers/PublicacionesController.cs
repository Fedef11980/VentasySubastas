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


        //Metodos para ver subastas con administrador
        public IActionResult AltaPublicacionVenta(int id) 
        {
            ViewBag.altaPublicacionVenta = miSistema.ObternerVentaPorId(id);   
            return View();  
        }
        
        public IActionResult ListarPublicacionesSubastas(int id) 
        {
            ViewBag.altaPublicacionSubastas = miSistema.ObternerSubastaPorId(id);
            return View();
        }

        /*public IActionResult ProcesarAltaSubasta(double monto)
        {
            try
            {
                if (monto < 0) throw new Exception("El monto tiene que ser mayor a cero");
                Subasta s = new Subasta(monto);
                miSistema.AgregarOfertaAUnaSubasta(s);
                ViewBag.Exito = $"La subasta se ingresó con exito";
            }
            catch(Exception ex) 
            {
                ViewBag.Error = ex.Message;
            }
            return View();  
        }*/


        public IActionResult DetalleArticulo()
        {
            ViewBag.detalleArticulo = miSistema.Articulos;
            return View();  
        }
    }
}
